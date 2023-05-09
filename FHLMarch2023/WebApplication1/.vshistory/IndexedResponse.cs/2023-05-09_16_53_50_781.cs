using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AudioEffect
    {
        public int id { get; set; }
        public string type { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Block
    {
        public int id { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Emotion
    {
        public int id { get; set; }
        public string type { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Face
    {
        public int id { get; set; }
        public string name { get; set; }
        public int confidence { get; set; }
        public string description { get; set; }
        public string thumbnailId { get; set; }
        public string referenceId { get; set; }
        public string referenceType { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Insights
    {
        public string version { get; set; }
        public string duration { get; set; }
        public string sourceLanguage { get; set; }
        public List<string> sourceLanguages { get; set; }
        public string language { get; set; }
        public List<string> languages { get; set; }
        public List<Transcript> transcript { get; set; }
        public List<Ocr> ocr { get; set; }
        public List<Keyword> keywords { get; set; }
        public List<Topic> topics { get; set; }
        public List<Face> faces { get; set; }
        public List<Label> labels { get; set; }
        public List<Shot> shots { get; set; }
        public List<AudioEffect> audioEffects { get; set; }
        public List<Sentiment> sentiments { get; set; }
        public List<Emotion> emotions { get; set; }
        public List<Block> blocks { get; set; }
        public List<Speaker> speakers { get; set; }
        public TextualContentModeration textualContentModeration { get; set; }
        public Statistics statistics { get; set; }
        public int sourceLanguageConfidence { get; set; }
    }

    public class Instance
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public List<string> thumbnailsIds { get; set; }
        public double confidence { get; set; }
        public string thumbnailId { get; set; }
    }

    public class KeyFrame
    {
        public int id { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Keyword
    {
        public int id { get; set; }
        public string text { get; set; }
        public double confidence { get; set; }
        public string language { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Label
    {
        public int id { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Ocr
    {
        public int id { get; set; }
        public string text { get; set; }
        public double confidence { get; set; }
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int angle { get; set; }
        public string language { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Range
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Root
    {
        public object partition { get; set; }
        public object description { get; set; }
        public string privacyMode { get; set; }
        public string state { get; set; }
        public string accountId { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public DateTime created { get; set; }
        public bool isOwned { get; set; }
        public bool isEditable { get; set; }
        public bool isBase { get; set; }
        public int durationInSeconds { get; set; }
        public string duration { get; set; }
        public object summarizedInsights { get; set; }
        public List<Video> videos { get; set; }
        public List<VideosRange> videosRanges { get; set; }
    }

    public class Sentiment
    {
        public int id { get; set; }
        public double averageScore { get; set; }
        public string sentimentType { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Shot
    {
        public int id { get; set; }
        public List<KeyFrame> keyFrames { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Speaker
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class SpeakerLongestMonolog
    {
        [JsonProperty("1")]
        public int _1 { get; set; }
    }

    public class SpeakerNumberOfFragments
    {
        [JsonProperty("1")]
        public int _1 { get; set; }
    }

    public class SpeakerTalkToListenRatio
    {
        [JsonProperty("1")]
        public int _1 { get; set; }
    }

    public class SpeakerWordCount
    {
        [JsonProperty("1")]
        public int _1 { get; set; }
    }

    public class Statistics
    {
        public int correspondenceCount { get; set; }
        public SpeakerTalkToListenRatio speakerTalkToListenRatio { get; set; }
        public SpeakerLongestMonolog speakerLongestMonolog { get; set; }
        public SpeakerNumberOfFragments speakerNumberOfFragments { get; set; }
        public SpeakerWordCount speakerWordCount { get; set; }
    }

    public class TextualContentModeration
    {
        public int id { get; set; }
        public int bannedWordsCount { get; set; }
        public int bannedWordsRatio { get; set; }
        public List<object> instances { get; set; }
    }

    public class Thumbnail
    {
        public string id { get; set; }
        public string fileName { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Topic
    {
        public int id { get; set; }
        public string name { get; set; }
        public string referenceId { get; set; }
        public string referenceType { get; set; }
        public double confidence { get; set; }
        public object iabName { get; set; }
        public string language { get; set; }
        public List<Instance> instances { get; set; }
        public string iptcName { get; set; }
    }

    public class Transcript
    {
        public int id { get; set; }
        public string text { get; set; }
        public double confidence { get; set; }
        public int speakerId { get; set; }
        public string language { get; set; }
        public List<Instance> instances { get; set; }
    }

    public class Video
    {
        public string accountId { get; set; }
        public string id { get; set; }
        public string state { get; set; }
        public string moderationState { get; set; }
        public string reviewState { get; set; }
        public string privacyMode { get; set; }
        public string processingProgress { get; set; }
        public string failureCode { get; set; }
        public string failureMessage { get; set; }
        public object externalId { get; set; }
        public object externalUrl { get; set; }
        public object metadata { get; set; }
        public Insights insights { get; set; }
        public string thumbnailId { get; set; }
        public bool detectSourceLanguage { get; set; }
        public string languageAutoDetectMode { get; set; }
        public string sourceLanguage { get; set; }
        public List<string> sourceLanguages { get; set; }
        public string language { get; set; }
        public List<string> languages { get; set; }
        public string indexingPreset { get; set; }
        public string linguisticModelId { get; set; }
        public string personModelId { get; set; }
        public object logoGroupId { get; set; }
        public bool isAdult { get; set; }
        public string publishedUrl { get; set; }
        public object publishedProxyUrl { get; set; }
        public string viewToken { get; set; }
    }

    public class VideosRange
    {
        public string videoId { get; set; }
        public Range range { get; set; }
    }


}
