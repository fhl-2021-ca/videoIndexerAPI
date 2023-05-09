namespace WebApplication1
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class IndexedResult
    {
        [JsonProperty("partition")]
        public string Partition { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("privacyMode")]
        public string PrivacyMode { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("accountId")]
        public Guid AccountId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("isOwned")]
        public bool IsOwned { get; set; }

        [JsonProperty("isEditable")]
        public bool IsEditable { get; set; }

        [JsonProperty("isBase")]
        public bool IsBase { get; set; }

        [JsonProperty("durationInSeconds")]
        public long DurationInSeconds { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("summarizedInsights")]
        public SummarizedInsights SummarizedInsights { get; set; }

        [JsonProperty("videos")]
        public Video[] Videos { get; set; }

        [JsonProperty("videosRanges")]
        public VideosRange[] VideosRanges { get; set; }
    }

    public partial class SummarizedInsights
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("privacyMode")]
        public string PrivacyMode { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("thumbnailVideoId")]
        public string ThumbnailVideoId { get; set; }

        [JsonProperty("thumbnailId")]
        public Guid ThumbnailId { get; set; }

        [JsonProperty("faces")]
        public SummarizedInsightsFace[] Faces { get; set; }

        [JsonProperty("keywords")]
        public SummarizedInsightsKeyword[] Keywords { get; set; }

        [JsonProperty("sentiments")]
        public SummarizedInsightsSentiment[] Sentiments { get; set; }

        [JsonProperty("emotions")]
        public object[] Emotions { get; set; }

        [JsonProperty("audioEffects")]
        public SummarizedInsightsAudioEffect[] AudioEffects { get; set; }

        [JsonProperty("labels")]
        public SummarizedInsightsLabel[] Labels { get; set; }

        [JsonProperty("framePatterns")]
        public object[] FramePatterns { get; set; }

        [JsonProperty("brands")]
        public NamedPersonElement[] Brands { get; set; }

        [JsonProperty("namedLocations")]
        public object[] NamedLocations { get; set; }

        [JsonProperty("namedPeople")]
        public NamedPersonElement[] NamedPeople { get; set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }

        [JsonProperty("topics")]
        public SummarizedInsightsTopic[] Topics { get; set; }
    }

    public partial class SummarizedInsightsAudioEffect
    {
        [JsonProperty("audioEffectKey")]
        public string AudioEffectKey { get; set; }

        [JsonProperty("seenDurationRatio")]
        public double SeenDurationRatio { get; set; }

        [JsonProperty("seenDuration")]
        public double SeenDuration { get; set; }

        [JsonProperty("appearances")]
        public Appearance[] Appearances { get; set; }
    }

    public partial class Appearance
    {
        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? Confidence { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("startSeconds")]
        public double StartSeconds { get; set; }

        [JsonProperty("endSeconds")]
        public double EndSeconds { get; set; }
    }

    public partial class NamedPersonElement
    {
        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("referenceUrl")]
        public Uri ReferenceUrl { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("seenDuration")]
        public double SeenDuration { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appearances")]
        public Appearance[] Appearances { get; set; }
    }

    public partial class Duration
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("seconds")]
        public double Seconds { get; set; }
    }

    public partial class SummarizedInsightsFace
    {
        [JsonProperty("videoId")]
        public string VideoId { get; set; }

        [JsonProperty("confidence")]
        public long Confidence { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("thumbnailId")]
        public Guid ThumbnailId { get; set; }

        [JsonProperty("seenDuration")]
        public double SeenDuration { get; set; }

        [JsonProperty("seenDurationRatio")]
        public double SeenDurationRatio { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appearances")]
        public Appearance[] Appearances { get; set; }
    }

    public partial class SummarizedInsightsKeyword
    {
        [JsonProperty("isTranscript")]
        public bool IsTranscript { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appearances")]
        public Appearance[] Appearances { get; set; }
    }

    public partial class SummarizedInsightsLabel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appearances")]
        public Appearance[] Appearances { get; set; }
    }

    public partial class SummarizedInsightsSentiment
    {
        [JsonProperty("sentimentKey")]
        public string SentimentKey { get; set; }

        [JsonProperty("seenDurationRatio")]
        public double SeenDurationRatio { get; set; }

        [JsonProperty("appearances")]
        public Appearance[] Appearances { get; set; }
    }

    public partial class Statistics
    {
        [JsonProperty("correspondenceCount")]
        public long CorrespondenceCount { get; set; }

        [JsonProperty("speakerTalkToListenRatio")]
        public Dictionary<string, double> SpeakerTalkToListenRatio { get; set; }

        [JsonProperty("speakerLongestMonolog")]
        public Dictionary<string, double> SpeakerLongestMonolog { get; set; }

        [JsonProperty("speakerNumberOfFragments")]
        public Dictionary<string, double> SpeakerNumberOfFragments { get; set; }

        [JsonProperty("speakerWordCount")]
        public Dictionary<string, double> SpeakerWordCount { get; set; }
    }

    public partial class SummarizedInsightsTopic
    {
        [JsonProperty("referenceUrl")]
        public Uri ReferenceUrl { get; set; }

        [JsonProperty("iptcName")]
        public string IptcName { get; set; }

        [JsonProperty("iabName")]
        public string IabName { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appearances")]
        public Appearance[] Appearances { get; set; }
    }

    public partial class Video
    {
        [JsonProperty("accountId")]
        public Guid AccountId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("moderationState")]
        public string ModerationState { get; set; }

        [JsonProperty("reviewState")]
        public string ReviewState { get; set; }

        [JsonProperty("privacyMode")]
        public string PrivacyMode { get; set; }

        [JsonProperty("processingProgress")]
        public string ProcessingProgress { get; set; }

        [JsonProperty("failureCode")]
        public string FailureCode { get; set; }

        [JsonProperty("failureMessage")]
        public string FailureMessage { get; set; }

        [JsonProperty("externalId")]
        public object ExternalId { get; set; }

        [JsonProperty("externalUrl")]
        public object ExternalUrl { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("insights")]
        public Insights Insights { get; set; }

        [JsonProperty("thumbnailId")]
        public Guid ThumbnailId { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("detectSourceLanguage")]
        public bool DetectSourceLanguage { get; set; }

        [JsonProperty("languageAutoDetectMode")]
        public string LanguageAutoDetectMode { get; set; }

        [JsonProperty("sourceLanguage")]
        public Language SourceLanguage { get; set; }

        [JsonProperty("sourceLanguages")]
        public Language[] SourceLanguages { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("languages")]
        public Language[] Languages { get; set; }

        [JsonProperty("indexingPreset")]
        public string IndexingPreset { get; set; }

        [JsonProperty("linguisticModelId")]
        public Guid LinguisticModelId { get; set; }

        [JsonProperty("personModelId")]
        public Guid PersonModelId { get; set; }

        [JsonProperty("logoGroupId")]
        public object LogoGroupId { get; set; }

        [JsonProperty("isAdult")]
        public bool IsAdult { get; set; }

        [JsonProperty("publishedUrl")]
        public Uri PublishedUrl { get; set; }

        [JsonProperty("publishedProxyUrl")]
        public object PublishedProxyUrl { get; set; }

        [JsonProperty("viewToken")]
        public string ViewToken { get; set; }
    }

    public partial class Insights
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("sourceLanguage")]
        public Language SourceLanguage { get; set; }

        [JsonProperty("sourceLanguages")]
        public Language[] SourceLanguages { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("languages")]
        public Language[] Languages { get; set; }

        [JsonProperty("transcript")]
        public TranscriptElement[] Transcript { get; set; }

        [JsonProperty("ocr")]
        public Ocr[] Ocr { get; set; }

        [JsonProperty("keywords")]
        public TranscriptElement[] Keywords { get; set; }

        [JsonProperty("topics")]
        public InsightsTopic[] Topics { get; set; }

        [JsonProperty("faces")]
        public InsightsFace[] Faces { get; set; }

        [JsonProperty("labels")]
        public InsightsLabel[] Labels { get; set; }

        [JsonProperty("scenes")]
        public Block[] Scenes { get; set; }

        [JsonProperty("shots")]
        public Shot[] Shots { get; set; }

        [JsonProperty("brands")]
        public InsightsBrand[] Brands { get; set; }

        [JsonProperty("namedPeople")]
        public NamedPerson[] NamedPeople { get; set; }

        [JsonProperty("audioEffects")]
        public InsightsAudioEffect[] AudioEffects { get; set; }

        [JsonProperty("sentiments")]
        public InsightsSentiment[] Sentiments { get; set; }

        [JsonProperty("blocks")]
        public Block[] Blocks { get; set; }

        [JsonProperty("speakers")]
        public Speaker[] Speakers { get; set; }

        [JsonProperty("textualContentModeration")]
        public TextualContentModeration TextualContentModeration { get; set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }
    }

    public partial class InsightsAudioEffect
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class AudioEffectInstance
    {
        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? Confidence { get; set; }

        [JsonProperty("adjustedStart")]
        public string AdjustedStart { get; set; }

        [JsonProperty("adjustedEnd")]
        public string AdjustedEnd { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("thumbnailsIds", NullValueHandling = NullValueHandling.Ignore)]
        public Guid[] ThumbnailsIds { get; set; }
    }

    public partial class Block
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class InsightsBrand
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("referenceType")]
        public string ReferenceType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("referenceUrl")]
        public Uri ReferenceUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("instances")]
        public BrandInstance[] Instances { get; set; }
    }

    public partial class BrandInstance
    {
        [JsonProperty("brandType", NullValueHandling = NullValueHandling.Ignore)]
        public BrandType? BrandType { get; set; }

        [JsonProperty("instanceSource", NullValueHandling = NullValueHandling.Ignore)]
        public BrandType? InstanceSource { get; set; }

        [JsonProperty("adjustedStart")]
        public string AdjustedStart { get; set; }

        [JsonProperty("adjustedEnd")]
        public string AdjustedEnd { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("thumbnailId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ThumbnailId { get; set; }
    }

    public partial class InsightsFace
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public long Confidence { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("thumbnailId")]
        public Guid ThumbnailId { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("imageUrl")]
        public object ImageUrl { get; set; }

        [JsonProperty("thumbnails")]
        public Thumbnail[] Thumbnails { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class Thumbnail
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class TranscriptElement
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("instances")]
        public KeywordInstance[] Instances { get; set; }

        [JsonProperty("speakerId", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpeakerId { get; set; }
    }

    public partial class KeywordInstance
    {
        [JsonProperty("adjustedStart")]
        public string AdjustedStart { get; set; }

        [JsonProperty("adjustedEnd")]
        public string AdjustedEnd { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }

    public partial class InsightsLabel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("referenceId", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class NamedPerson
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("referenceUrl")]
        public Uri ReferenceUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("instances")]
        public BrandInstance[] Instances { get; set; }
    }

    public partial class Ocr
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("left")]
        public long Left { get; set; }

        [JsonProperty("top")]
        public long Top { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("angle")]
        public long Angle { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class InsightsSentiment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("averageScore")]
        public double AverageScore { get; set; }

        [JsonProperty("sentimentType")]
        public string SentimentType { get; set; }

        [JsonProperty("instances")]
        public BrandInstance[] Instances { get; set; }
    }

    public partial class Shot
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }

        [JsonProperty("keyFrames")]
        public KeyFrame[] KeyFrames { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class KeyFrame
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("instances")]
        public BrandInstance[] Instances { get; set; }
    }

    public partial class Speaker
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("instances")]
        public AudioEffectInstance[] Instances { get; set; }
    }

    public partial class TextualContentModeration
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("bannedWordsCount")]
        public long BannedWordsCount { get; set; }

        [JsonProperty("bannedWordsRatio")]
        public long BannedWordsRatio { get; set; }

        [JsonProperty("instances")]
        public object[] Instances { get; set; }
    }

    public partial class InsightsTopic
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("referenceType")]
        public string ReferenceType { get; set; }

        [JsonProperty("iptcName", NullValueHandling = NullValueHandling.Ignore)]
        public string IptcName { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("iabName")]
        public string IabName { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("instances")]
        public BrandInstance[] Instances { get; set; }

        [JsonProperty("referenceUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ReferenceUrl { get; set; }
    }

    public partial class VideosRange
    {
        [JsonProperty("videoId")]
        public string VideoId { get; set; }

        [JsonProperty("range")]
        public Range Range { get; set; }
    }

    public partial class Range
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }

    public enum BrandType { Ocr, Transcript };

    public enum Language { EnUs };

    public enum Tag { RightFace, Wide };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                BrandTypeConverter.Singleton,
                LanguageConverter.Singleton,
                TagConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class BrandTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BrandType) || t == typeof(BrandType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Ocr":
                    return BrandType.Ocr;
                case "Transcript":
                    return BrandType.Transcript;
            }
            throw new Exception("Cannot unmarshal type BrandType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BrandType)untypedValue;
            switch (value)
            {
                case BrandType.Ocr:
                    serializer.Serialize(writer, "Ocr");
                    return;
                case BrandType.Transcript:
                    serializer.Serialize(writer, "Transcript");
                    return;
            }
            throw new Exception("Cannot marshal type BrandType");
        }

        public static readonly BrandTypeConverter Singleton = new BrandTypeConverter();
    }

    internal class LanguageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Language) || t == typeof(Language?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "en-US")
            {
                return Language.EnUs;
            }
            throw new Exception("Cannot unmarshal type Language");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Language)untypedValue;
            if (value == Language.EnUs)
            {
                serializer.Serialize(writer, "en-US");
                return;
            }
            throw new Exception("Cannot marshal type Language");
        }

        public static readonly LanguageConverter Singleton = new LanguageConverter();
    }

    internal class TagConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Tag) || t == typeof(Tag?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "RightFace":
                    return Tag.RightFace;
                case "Wide":
                    return Tag.Wide;
            }
            throw new Exception("Cannot unmarshal type Tag");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Tag)untypedValue;
            switch (value)
            {
                case Tag.RightFace:
                    serializer.Serialize(writer, "RightFace");
                    return;
                case Tag.Wide:
                    serializer.Serialize(writer, "Wide");
                    return;
            }
            throw new Exception("Cannot marshal type Tag");
        }

        public static readonly TagConverter Singleton = new TagConverter();
    }
}
