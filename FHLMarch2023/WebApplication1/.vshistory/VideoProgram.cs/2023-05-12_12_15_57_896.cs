using Azure;
using Azure.AI.OpenAI;
using Azure.Core;
using Azure.Identity;
using OpenAI_API;
using OpenAI_API.Moderation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using WebApplication1;

namespace VideoIndexerArm
{
    public static class VideoProgram
    {
        private const string ApiVersion = "2022-08-01";
        private const string AzureResourceManager = "https://management.azure.com";
        //private const string VideoUrl = "https://aseemgoyalstorageaccount.blob.core.windows.net/fhl/SP search semantic search short.mp4";
        private const string ApiUrl = "https://api.videoindexer.ai";

        private const string SubscriptionId = "1efcfc5c-8fc0-44da-a91a-99b94841290b";
        private const string ResourceGroup = "aseemgoyalFHL";
        private const string AccountName = "videoindexeraseem2";
        private static OpenAIAPI api = new OpenAIAPI(new APIAuthentication("1512d51d6f6f49159e1807913499c388"));

        public static async Task<string> indexvideo(string VideoUrl)
        {
            // Build Azure Video Indexer resource provider client that has access token throuhg ARM
            var videoIndexerResourceProviderClient = await VideoIndexerResourceProviderClient.BuildVideoIndexerResourceProviderClient();

            // Get account details
            var account = await videoIndexerResourceProviderClient.GetAccount();
            var accountLocation = account.Location;
            var accountId = account.Properties.Id;

            // Get account level access token for Azure Video Indexer 
            var accountAccessToken = await videoIndexerResourceProviderClient.GetAccessToken(ArmAccessTokenPermission.Contributor, ArmAccessTokenScope.Account);

            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls13;

            // Create the http client
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);

            // Upload a video
            var videoId = await UploadVideo(accountId, accountLocation, accountAccessToken, ApiUrl, client, VideoUrl);

            // Wait for the video index to finish
            String results = await WaitForIndex(accountId, accountLocation, accountAccessToken, ApiUrl, client, videoId);

            var videoAccessToken = await videoIndexerResourceProviderClient.GetAccessToken(ArmAccessTokenPermission.Contributor, ArmAccessTokenScope.Video, videoId);

            // Search for the video
            await GetVideoAsync(accountId, accountLocation, videoAccessToken, ApiUrl, client, videoId);

            return results;

        }
        public static async Task<String> GetInsights(string videoId)
        {
            var videoIndexerResourceProviderClient = await VideoIndexerResourceProviderClient.BuildVideoIndexerResourceProviderClient();

            // Get account details
            var account = await videoIndexerResourceProviderClient.GetAccount();
            var accountLocation = account.Location;
            var accountId = account.Properties.Id;

            // Get account level access token for Azure Video Indexer 
            var accountAccessToken = await videoIndexerResourceProviderClient.GetAccessToken(ArmAccessTokenPermission.Contributor, ArmAccessTokenScope.Account);

            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls13;

            // Create the http client
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            String results = await WaitForIndex(accountId, accountLocation, accountAccessToken, ApiUrl, client, videoId);
            IndexedResult response = IndexedResult.FromJson(results);
            Video video = response.Videos[0];
            List<Transcript> transcripts = video.Insights.Transcript;
            List<Sentiment> sentiments = video.Insights.Sentiments;
            List<Emotion> emotions = video.Insights.Emotions;
            // List of -ve sentiment to list of emotions
            List<WorkingSet> workingSets = new List<WorkingSet>();


            Sentiment negativeSentiment = sentiments.Find(x => x.SentimentType.Equals("Negative"));
            Sentiment neutralSentiment = sentiments.Find(x => x.SentimentType.Equals("Neutral"));

            List<WorkingSet> NegativeSet = doSentiment(negativeSentiment, transcripts, emotions, workingSets);
            List<WorkingSet> NeutralSet = doSentiment(neutralSentiment, transcripts, emotions, workingSets);

            // Now we have -ve sentiment and corresponding emotions in same time interval
            // Combine it with actual transcript
            /*
                        var chat = api.Chat.CreateConversation();
                        // now let's ask it a question'
                        chat.AppendUserInput("Is this an animal? Dog");
                        // and get the response
                        string gptResponse = await chat.GetResponseFromChatbotAsync();
                        Console.WriteLine(gptResponse); // "Yes"
            */

            if(NegativeSet != null)
            {
                for (int i = 0; i < NegativeSet.Count; i++)
                {
                    WorkingSet workingSet = NegativeSet[i];
                    List<Transcript> transcript;
                    List<Transcript> transcript2;
                    if (workingSet.transcript.ContainsKey("Both"))
                    {
                        workingSet.transcript.TryGetValue("Both", out transcript);
                        createGPTInput(transcript, workingSet.emotions);

                        getGPTResponse(transcript, workingSet.emotions);
                    }
                    else
                    {
                        workingSet.transcript.TryGetValue("First", out transcript);
                        workingSet.transcript.TryGetValue("Second", out transcript2);
                    }
                }

            }

        }

        private static void createGPTInput(List<Transcript> transcript, Emotion emotions)
        {
            for (int i = 0; i < transcript.Count; i++)
            {
                Transcript transcript1 = transcript[i];
                String message = transcript1.SpeakerId + ": " + transcript1.Text;
            }

        }

        private static void getGPTResponse(List<Transcript> transcript, Emotion emotions)
        {

            #region Snippet:GenerateChatbotResponse
            #region Snippet:CreateOpenAIClientTokenCredential
            string endpoint = "https://fhlmayjas.openai.azure.com/";
            var client2 = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential("1512d51d6f6f49159e1807913499c388"));
            #endregion

            string deploymentName = "GPT35Turbo";
            string prompt = "Imagine yourself as D&I coach. \n\nThis is the transcript showing negative sentiments and fear by Hema.\n\nAseem: [Angry and fast] Look, I\'m too busy with important tasks to guide you through this. See, It\'s your responsibility to do your own research and figure out how to design architectures that work at this scale.You\'re a junior engineer, and you have a long way to go before you can come up with good designs. \n\nHema: oh, I \'m sorry. I will work harder to improve my skills. I will set up another meeting with updated architecture.\n\nAseem: Okay, let�s set up another meeting once you are ready with the new proposal.\n\nWhat Hema could have said differently to change this negative sentiment to positive from D&I perspective ?";
            Console.Write($"Input: {prompt}");

            Response<Completions> completionsResponse = client2.GetCompletions(deploymentName, prompt);
            string completion = completionsResponse.Value.Choices[0].Text;
            Console.WriteLine($"Chatbot: {completion}");
            #endregion

            return completion;
        }

        // returns Working set for a sentiment... each working set will be sent to chatGPT one by one to generate insights
        // The emotion will be linked to the first person...
        // a Map with key -> Both, if converstaion of both speakers is there,
        // else we have 2 keys --> First and Second as keys, where value is what the 1st person said and then what the 2nd person said.
        private static List<WorkingSet> doSentiment(Sentiment negativeSentiment, List<Transcript> transcripts, List<Emotion> emotions, List<WorkingSet> workingSets)
        {

            if (negativeSentiment == null)
                return null;

            for (int i = 0; i < negativeSentiment.Instances.Count; i++)
            {
                Instance sentimentInstance = negativeSentiment.Instances[i];
                Console.WriteLine($"Checking for sentiment : {sentimentInstance.Start} and {sentimentInstance.End} \n\n");
                TimeSpan start = TimeSpan.Parse(sentimentInstance.Start);
                TimeSpan end = TimeSpan.Parse(sentimentInstance.End);
                double differenceInSeconds = (end - start).TotalSeconds;

                // don't pick up too short dialogues 
                if (differenceInSeconds <= 2)
                    continue;

                WorkingSet workingSet = new WorkingSet();
                workingSet.sentiment = sentimentInstance;
                workingSet.transcript = new Dictionary<String, List<Transcript>>();

                List<Emotion> newEmotions = new List<Emotion>();

                // for each -ve sentiment, find emotions
                for (int emotionIdx = 0; emotionIdx < emotions.Count; emotionIdx++)
                {
                    Emotion audioEffect = emotions[emotionIdx];
                    List<Instance> emotionInstances = audioEffect.Instances.FindAll(x => withinTimeInterval(x, sentimentInstance));
                    if(emotionInstances.Count >=1)
                    {
                        // we only need 1 emotion
                        workingSet.emotions = emotions[emotionIdx];
                        break;
                    }

/*                  Emotion newAudioEffect = new Emotion();
                    newAudioEffect.Id = audioEffect.Id;
                    newAudioEffect.Type = audioEffect.Type;
                    newAudioEffect.Instances = emotionInstances;

                    newEmotions.Add(newAudioEffect);*/
                }

//                workingSet.emotions = newEmotions;

                List<Transcript> newTranscripts = new List<Transcript>();
                HashSet<long> speakers = new HashSet<long>();
                // for each -ve sentiment, attach the transcript
                for (int transcriptidx = 0; transcriptidx < transcripts.Count; transcriptidx++)
                {
                    Transcript transcript = transcripts[transcriptidx];
                    List<Instance> transcriptInstances = transcript.Instances.FindAll(x => withinTimeInterval(x, sentimentInstance));

                    if(transcriptInstances.Count != 0)
                    {
                        Transcript newTranscript = new Transcript();
                        newTranscript.Id = transcript.Id;
                        newTranscript.Text = transcript.Text;
                        newTranscript.SpeakerId = transcript.SpeakerId;
                        speakers.Add(transcript.SpeakerId.Value);
                        newTranscript.Instances = transcriptInstances;

                        newTranscripts.Add(newTranscript);
                        Console.WriteLine($"Adding transcript : {transcript.Text}");
                    }
                }

                // fetch next conversation of next speaker, we want a dialogue
                if(speakers.Count <=1)
                {
                    workingSet.transcript.Add("First", newTranscripts);
                    bool first = speakers.Contains(1);
                    long actualSpeaker = 1;
                    if(first == false)
                    {
                        actualSpeaker = 2;
                    }

                    List<Transcript> otherSpeakerTranscripts = new List<Transcript>();
                    otherSpeakerTranscripts = transcripts.FindAll(x => x.SpeakerId != actualSpeaker);
                    for (int transcriptidx = 0; transcriptidx < otherSpeakerTranscripts.Count; transcriptidx++)
                    {
                        Transcript transcript = otherSpeakerTranscripts[transcriptidx];
                        Instance transcriptInstances = transcript.Instances.Find(x => (TimeSpan.Parse(x.Start) - TimeSpan.Parse(sentimentInstance.End)).TotalSeconds >= 0);

                        // get just 1 transcript from other speaker
                        if (transcriptInstances != null)
                        {
                            Console.WriteLine($"Adding text for 2nd speaker : {transcript.Text}");

                            Transcript newTranscript = new Transcript();
                            newTranscript.Id = transcript.Id;
                            newTranscript.Text = transcript.Text;
                            newTranscript.SpeakerId = transcript.SpeakerId;
                            speakers.Add(transcript.SpeakerId.Value);
                            newTranscript.Instances = new List<Instance>{transcriptInstances};

                            workingSet.transcript.Add("Second", new List<Transcript> { newTranscript });

                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Unable to find 2nd speaker, transcript: {transcript.Text}");

                        }
                    }

                }
                else
                {
                    workingSet.transcript.Add("Both", newTranscripts);
                    Console.WriteLine($"Found both speakers");
                }

                if (workingSet.transcript.ContainsKey("Both") || workingSet.transcript.ContainsKey("Second"))
                {
                    workingSets.Add(workingSet);
                }
            }

            return workingSets;
        }

        private static bool withinTimeInterval(Instance x, Instance sentimentInstance)
        {
            TimeSpan start = TimeSpan.Parse(sentimentInstance.Start);
            TimeSpan end = TimeSpan.Parse(sentimentInstance.End);

            return (TimeSpan.Parse(x.Start) - TimeSpan.Parse(sentimentInstance.Start)).TotalSeconds >= 0 
                && (TimeSpan.Parse(x.End) - TimeSpan.Parse(sentimentInstance.End)).TotalSeconds <= 0;
        }

        /// <summary>
        /// Uploads a video and starts the video index. Calls the uploadVideo API (https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Upload-Video)
        /// </summary>
        /// <param name="accountId"> The account ID</param>
        /// <param name="accountLocation"> The account location </param>
        /// <param name="acountAccessToken"> The access token </param>
        /// <param name="apiUrl"> The video indexer api url </param>
        /// <param name="client"> The http client </param>
        /// <returns> Video Id of the video being indexed, otherwise throws excpetion</returns>
        private static async Task<string> UploadVideo(string accountId, string accountLocation, string acountAccessToken, string apiUrl, HttpClient client, String VideoUrl)
        {
            Console.WriteLine($"Video for account {accountId} is starting to upload.");
            var content = new MultipartFormDataContent();

            try
            {
                // Get the video from URL
                var queryParams = CreateQueryString(
                new Dictionary<string, string>()
                {
                    {"accessToken", acountAccessToken},
                    {"name", "video sample"},
                    {"description", "video_description"},
                    {"privacy", "private"},
                    {"partition", "partition"},
                    {"videoUrl", VideoUrl},
                });

                // As an alternative to specifying video URL, you can upload a file.
                // Remove the videoUrl parameter from the query params below and add the following lines:
                // FileStream video =File.OpenRead(Globals.VIDEOFILE_PATH);
                // byte[] buffer =new byte[video.Length];
                // video.Read(buffer, 0, buffer.Length);
                // content.Add(new ByteArrayContent(buffer));

                var uploadRequestResult = await client.PostAsync($"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos?{queryParams}", content);
                VerifyStatus(uploadRequestResult, System.Net.HttpStatusCode.OK);
                var uploadResult = await uploadRequestResult.Content.ReadAsStringAsync();

                // Get the video ID from the upload result
                var videoId = JsonSerializer.Deserialize<VideoRequest>(uploadResult).Id;
                Console.WriteLine($"\nVideo ID {videoId} was uploaded successfully");
                return videoId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Calls getVideoIndex API in 10 second intervals until the indexing state is 'processed'(https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index)
        /// </summary>
        /// <param name="accountId"> The account ID</param>
        /// <param name="accountLocation"> The account location </param>
        /// <param name="acountAccessToken"> The access token </param>
        /// <param name="apiUrl"> The video indexer api url </param>
        /// <param name="client"> The http client </param>
        /// <param name="videoId"> The video id </param>
        /// <returns> Prints video index when the index is complete, otherwise throws exception </returns>
        private static async Task<String> WaitForIndex(string accountId, string accountLocation, string acountAccessToken, string apiUrl, HttpClient client, string videoId)
        {
            Console.WriteLine($"\nWaiting for video {videoId} to finish indexing.");
            string queryParams;
            while (true)
            {
                queryParams = CreateQueryString(
                    new Dictionary<string, string>()
                    {
                            {"accessToken", acountAccessToken},
                            {"language", "English"},
                    });

                var videoGetIndexRequestResult = await client.GetAsync($"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/Index?{queryParams}");

                VerifyStatus(videoGetIndexRequestResult, System.Net.HttpStatusCode.OK);
                var videoGetIndexResult = await videoGetIndexRequestResult.Content.ReadAsStringAsync();
                string processingState = JsonSerializer.Deserialize<VideoRequest>(videoGetIndexResult).State;

                // If job is finished
                if (processingState == ProcessingState.Processed.ToString())
                {
                    Console.WriteLine($"The video index has completed. Here is the full JSON of the index for video ID {videoId}: \n{videoGetIndexResult}");
                    return videoGetIndexResult;
                }
                else if (processingState == ProcessingState.Failed.ToString())
                {
                    Console.WriteLine($"\nThe video index failed for video ID {videoId}.");
                    throw new Exception(videoGetIndexResult);
                }

                // Job hasn't finished
                Console.WriteLine($"\nThe video index state is {processingState}");
                await Task.Delay(10000);
            }
        }

        /// <summary>
        /// Searches for the video in the account. Calls the searchVideo API (https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Search-Videos)
        /// </summary>
        /// <param name="accountId"> The account ID</param>
        /// <param name="accountLocation"> The account location </param>
        /// <param name="videoAccessToken"> The access token </param>
        /// <param name="apiUrl"> The video indexer api url </param>
        /// <param name="client"> The http client </param>
        /// <param name="videoId"> The video id </param>
        /// <returns> Prints the video metadata, otherwise throws excpetion</returns>
        private static async Task<string> GetVideoAsync(string accountId, string accountLocation, string videoAccessToken, string apiUrl, HttpClient client, string videoId)
        {
            Console.WriteLine($"\nSearching videos in account {AccountName} for video ID {videoId}.");
            var queryParams = CreateQueryString(
                new Dictionary<string, string>()
                {
                        {"accessToken", videoAccessToken},
                        {"id", videoId},
                });

            try
            {
                var searchRequestResult = await client.GetAsync($"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/Search?{queryParams}");

                VerifyStatus(searchRequestResult, System.Net.HttpStatusCode.OK);
                var searchResult = await searchRequestResult.Content.ReadAsStringAsync();
                Console.WriteLine($"Here are the search results: \n{searchResult}");
                return searchResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Calls the getVideoInsightsWidget API (https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Insights-Widget)
        /// </summary>
        /// <param name="accountId"> The account ID</param>
        /// <param name="accountLocation"> The account location </param>
        /// <param name="videoAccessToken"> The access token </param>
        /// <param name="apiUrl"> The video indexer api url </param>
        /// <param name="client"> The http client </param>
        /// <param name="videoId"> The video id </param>
        /// <returns> Prints the VideoInsightsWidget URL, otherwise throws exception</returns>
        private static async Task GetInsightsWidgetUrl(string accountId, string accountLocation, string videoAccessToken, string apiUrl, HttpClient client, string videoId)
        {
            Console.WriteLine($"\nGetting the insights widget URL for video {videoId}");
            var queryParams = CreateQueryString(
                new Dictionary<string, string>()
                {
                    {"accessToken", videoAccessToken},
                    {"widgetType", "Keywords"},
                    {"allowEdit", "true"},
                });
            try
            {
                var insightsWidgetRequestResult = await client.GetAsync($"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/InsightsWidget?{queryParams}");

                VerifyStatus(insightsWidgetRequestResult, System.Net.HttpStatusCode.MovedPermanently);
                var insightsWidgetLink = insightsWidgetRequestResult.Headers.Location;
                Console.WriteLine($"Got the insights widget URL: \n{insightsWidgetLink}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Calls the getVideoPlayerWidget API (https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Player-Widget)
        /// </summary>
        /// <param name="accountId"> The account ID</param>
        /// <param name="accountLocation"> The account location </param>
        /// <param name="videoAccessToken"> The access token </param>
        /// <param name="apiUrl"> The video indexer api url </param>
        /// <param name="client"> The http client </param>
        /// <param name="videoId"> The video id </param>
        /// <returns> Prints the VideoPlayerWidget URL, otherwise throws exception</returns>
        private static async Task GetPlayerWidgetUrl(string accountId, string accountLocation, string videoAccessToken, string apiUrl, HttpClient client, string videoId)
        {
            Console.WriteLine($"\nGetting the player widget URL for video {videoId}");
            var queryParams = CreateQueryString(
                new Dictionary<string, string>()
                {
                    {"accessToken", videoAccessToken},
                });

            try
            {
                var playerWidgetRequestResult = await client.GetAsync($"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/PlayerWidget?{queryParams}");

                var playerWidgetLink = playerWidgetRequestResult.Headers.Location;
                VerifyStatus(playerWidgetRequestResult, System.Net.HttpStatusCode.MovedPermanently);
                Console.WriteLine($"Got the player widget URL: \n{playerWidgetLink}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static string CreateQueryString(IDictionary<string, string> parameters)
        {
            var queryParameters = HttpUtility.ParseQueryString(string.Empty);
            foreach (var parameter in parameters)
            {
                queryParameters[parameter.Key] = parameter.Value;
            }

            return queryParameters.ToString();
        }

        public class VideoIndexerResourceProviderClient
        {
            private readonly string armAccessToken;

            async public static Task<VideoIndexerResourceProviderClient> BuildVideoIndexerResourceProviderClient()
            {
                var tokenRequestContext = new TokenRequestContext(new[] { $"{AzureResourceManager}/.default" });
                var tokenRequestResult = await new DefaultAzureCredential().GetTokenAsync(tokenRequestContext);
                return new VideoIndexerResourceProviderClient(tokenRequestResult.Token);
            }
            public VideoIndexerResourceProviderClient(string armAaccessToken)
            {
                this.armAccessToken = armAaccessToken;
            }

            /// <summary>
            /// Generates an access token. Calls the generateAccessToken API  (https://github.com/Azure/azure-rest-api-specs/blob/main/specification/vi/resource-manager/Microsoft.VideoIndexer/stable/2022-08-01/vi.json#:~:text=%22/subscriptions/%7BsubscriptionId%7D/resourceGroups/%7BresourceGroupName%7D/providers/Microsoft.VideoIndexer/accounts/%7BaccountName%7D/generateAccessToken%22%3A%20%7B)
            /// </summary>
            /// <param name="permission"> The permission for the access token</param>
            /// <param name="scope"> The scope of the access token </param>
            /// <param name="videoId"> if the scope is video, this is the video Id </param>
            /// <param name="projectId"> If the scope is project, this is the project Id </param>
            /// <returns> The access token, otherwise throws an exception</returns>
            public async Task<string> GetAccessToken(ArmAccessTokenPermission permission, ArmAccessTokenScope scope, string videoId = null, string projectId = null)
            {
                var accessTokenRequest = new AccessTokenRequest
                {
                    PermissionType = permission,
                    Scope = scope,
                    VideoId = videoId,
                    ProjectId = projectId
                };

                Console.WriteLine($"\nGetting access token: {JsonSerializer.Serialize(accessTokenRequest)}");

                // Set the generateAccessToken (from video indexer) http request content
                try
                {
                    var jsonRequestBody = JsonSerializer.Serialize(accessTokenRequest);
                    var httpContent = new StringContent(jsonRequestBody, System.Text.Encoding.UTF8, "application/json");

                    // Set request uri
                    var requestUri = $"{AzureResourceManager}/subscriptions/{SubscriptionId}/resourcegroups/{ResourceGroup}/providers/Microsoft.VideoIndexer/accounts/{AccountName}/generateAccessToken?api-version={ApiVersion}";
                    var client = new HttpClient(new HttpClientHandler());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", armAccessToken);

                    var result = await client.PostAsync(requestUri, httpContent);

                    VerifyStatus(result, System.Net.HttpStatusCode.OK);
                    var jsonResponseBody = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"Got access token: {scope} {videoId}, {permission}");
                    return JsonSerializer.Deserialize<GenerateAccessTokenResponse>(jsonResponseBody).AccessToken;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }

            /// <summary>
            /// Gets an account. Calls the getAccount API (https://github.com/Azure/azure-rest-api-specs/blob/main/specification/vi/resource-manager/Microsoft.VideoIndexer/stable/2022-08-01/vi.json#:~:text=%22/subscriptions/%7BsubscriptionId%7D/resourceGroups/%7BresourceGroupName%7D/providers/Microsoft.VideoIndexer/accounts/%7BaccountName%7D%22%3A%20%7B)
            /// </summary>
            /// <returns> The Account, otherwise throws an exception</returns>
            public async Task<Account> GetAccount()
            {
                Console.WriteLine($"Getting account {AccountName}.");
                Account account;
                try
                {
                    // Set request uri
                    var requestUri = $"{AzureResourceManager}/subscriptions/{SubscriptionId}/resourcegroups/{ResourceGroup}/providers/Microsoft.VideoIndexer/accounts/{AccountName}?api-version={ApiVersion}";
                    var client = new HttpClient(new HttpClientHandler());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", armAccessToken);

                    var result = await client.GetAsync(requestUri);

                    VerifyStatus(result, System.Net.HttpStatusCode.OK);
                    var jsonResponseBody = await result.Content.ReadAsStringAsync();
                    account = JsonSerializer.Deserialize<Account>(jsonResponseBody);
                    VerifyValidAccount(account);
                    Console.WriteLine($"The account ID is {account.Properties.Id}");
                    Console.WriteLine($"The account location is {account.Location}");
                    return account;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }

            private static void VerifyValidAccount(Account account)
            {
                if (string.IsNullOrWhiteSpace(account.Location) || account.Properties == null || string.IsNullOrWhiteSpace(account.Properties.Id))
                {
                    Console.WriteLine($"{nameof(AccountName)} {AccountName} not found. Check {nameof(SubscriptionId)}, {nameof(ResourceGroup)}, {nameof(AccountName)} ar valid.");
                    throw new Exception($"Account {AccountName} not found.");
                }
            }
        }

        public class AccessTokenRequest
        {
            [JsonPropertyName("permissionType")]
            public ArmAccessTokenPermission PermissionType { get; set; }

            [JsonPropertyName("scope")]
            public ArmAccessTokenScope Scope { get; set; }

            [JsonPropertyName("projectId")]
            public string ProjectId { get; set; }

            [JsonPropertyName("videoId")]
            public string VideoId { get; set; }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ArmAccessTokenPermission
        {
            Reader,
            Contributor,
            MyAccessAdministrator,
            Owner,
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ArmAccessTokenScope
        {
            Account,
            Project,
            Video
        }

        public class GenerateAccessTokenResponse
        {
            [JsonPropertyName("accessToken")]
            public string AccessToken { get; set; }
        }

        public class AccountProperties
        {
            [JsonPropertyName("accountId")]
            public string Id { get; set; }
        }

        public class Account
        {
            [JsonPropertyName("properties")]
            public AccountProperties Properties { get; set; }

            [JsonPropertyName("location")]
            public string Location { get; set; }
        }

        public class VideoRequest
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("state")]
            public string State { get; set; }
        }

        public enum ProcessingState
        {
            Uploaded,
            Processing,
            Processed,
            Failed
        }

        public static void VerifyStatus(HttpResponseMessage response, System.Net.HttpStatusCode excpectedStatusCode)
        {
            if (response.StatusCode != excpectedStatusCode)
            {
                throw new Exception(response.ToString());
            }
        }
    }
}