﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using WebApplication1;
//
//    var indexedResult = IndexedResult.FromJson(jsonString);

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
        public virtual object Partition { get; set; }

        [JsonProperty("description")]
        public virtual object Description { get; set; }

        [JsonProperty("privacyMode")]
        public virtual string PrivacyMode { get; set; }

        [JsonProperty("state")]
        public virtual string State { get; set; }

        [JsonProperty("accountId")]
        public virtual Guid AccountId { get; set; }

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("userName")]
        public virtual string UserName { get; set; }

        [JsonProperty("created")]
        public virtual DateTimeOffset Created { get; set; }

        [JsonProperty("isOwned")]
        public virtual bool IsOwned { get; set; }

        [JsonProperty("isEditable")]
        public virtual bool IsEditable { get; set; }

        [JsonProperty("isBase")]
        public virtual bool IsBase { get; set; }

        [JsonProperty("durationInSeconds")]
        public virtual long DurationInSeconds { get; set; }

        [JsonProperty("duration")]
        public virtual string Duration { get; set; }

        [JsonProperty("summarizedInsights")]
        public virtual object SummarizedInsights { get; set; }

        [JsonProperty("videos")]
        public virtual VideoResponse[] Videos { get; set; }

        [JsonProperty("videosRanges")]
        public virtual VideosRange[] VideosRanges { get; set; }
    }

    public partial class VideoResponse
    {
        [JsonProperty("accountId")]
        public virtual Guid AccountId { get; set; }

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("state")]
        public virtual string State { get; set; }

        [JsonProperty("moderationState")]
        public virtual string ModerationState { get; set; }

        [JsonProperty("reviewState")]
        public virtual string ReviewState { get; set; }

        [JsonProperty("privacyMode")]
        public virtual string PrivacyMode { get; set; }

        [JsonProperty("processingProgress")]
        public virtual string ProcessingProgress { get; set; }

        [JsonProperty("failureCode")]
        public virtual string FailureCode { get; set; }

        [JsonProperty("failureMessage")]
        public virtual string FailureMessage { get; set; }

        [JsonProperty("externalId")]
        public virtual object ExternalId { get; set; }

        [JsonProperty("externalUrl")]
        public virtual object ExternalUrl { get; set; }

        [JsonProperty("metadata")]
        public virtual object Metadata { get; set; }

        [JsonProperty("insights")]
        public virtual Insights Insights { get; set; }

        [JsonProperty("thumbnailId")]
        public virtual Guid ThumbnailId { get; set; }

        [JsonProperty("detectSourceLanguage")]
        public virtual bool DetectSourceLanguage { get; set; }

        [JsonProperty("languageAutoDetectMode")]
        public virtual string LanguageAutoDetectMode { get; set; }

        [JsonProperty("sourceLanguage")]
        public virtual Language SourceLanguage { get; set; }

        [JsonProperty("sourceLanguages")]
        public virtual Language[] SourceLanguages { get; set; }

        [JsonProperty("language")]
        public virtual Language Language { get; set; }

        [JsonProperty("languages")]
        public virtual Language[] Languages { get; set; }

        [JsonProperty("indexingPreset")]
        public virtual string IndexingPreset { get; set; }

        [JsonProperty("linguisticModelId")]
        public virtual Guid LinguisticModelId { get; set; }

        [JsonProperty("personModelId")]
        public virtual Guid PersonModelId { get; set; }

        [JsonProperty("logoGroupId")]
        public virtual object LogoGroupId { get; set; }

        [JsonProperty("isAdult")]
        public virtual bool IsAdult { get; set; }

        [JsonProperty("publishedUrl")]
        public virtual Uri PublishedUrl { get; set; }

        [JsonProperty("publishedProxyUrl")]
        public virtual object PublishedProxyUrl { get; set; }

        [JsonProperty("viewToken")]
        public virtual string ViewToken { get; set; }
    }

    public partial class Insights
    {
        [JsonProperty("version")]
        public virtual string Version { get; set; }

        [JsonProperty("duration")]
        public virtual string Duration { get; set; }

        [JsonProperty("sourceLanguage")]
        public virtual Language SourceLanguage { get; set; }

        [JsonProperty("sourceLanguages")]
        public virtual Language[] SourceLanguages { get; set; }

        [JsonProperty("language")]
        public virtual Language Language { get; set; }

        [JsonProperty("languages")]
        public virtual Language[] Languages { get; set; }

        [JsonProperty("transcript")]
        public virtual Keyword[] Transcript { get; set; }

        [JsonProperty("ocr")]
        public virtual Ocr[] Ocr { get; set; }

        [JsonProperty("keywords")]
        public virtual Keyword[] Keywords { get; set; }

        [JsonProperty("topics")]
        public virtual Topic[] Topics { get; set; }

        [JsonProperty("faces")]
        public virtual Face[] Faces { get; set; }

        [JsonProperty("labels")]
        public virtual Label[] Labels { get; set; }

        [JsonProperty("shots")]
        public virtual Shot[] Shots { get; set; }

        [JsonProperty("audioEffects")]
        public virtual AudioEffect[] AudioEffects { get; set; }

        [JsonProperty("sentiments")]
        public virtual Sentiment[] Sentiments { get; set; }

        [JsonProperty("emotions")]
        public virtual AudioEffect[] Emotions { get; set; }

        [JsonProperty("blocks")]
        public virtual Block[] Blocks { get; set; }

        [JsonProperty("speakers")]
        public virtual Speaker[] Speakers { get; set; }

        [JsonProperty("textualContentModeration")]
        public virtual TextualContentModeration TextualContentModeration { get; set; }

        [JsonProperty("statistics")]
        public virtual Statistics Statistics { get; set; }

        [JsonProperty("sourceLanguageConfidence")]
        public virtual long SourceLanguageConfidence { get; set; }
    }

    public partial class AudioEffect
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Instance
    {
        [JsonProperty("adjustedStart")]
        public virtual string AdjustedStart { get; set; }

        [JsonProperty("adjustedEnd")]
        public virtual string AdjustedEnd { get; set; }

        [JsonProperty("start")]
        public virtual string Start { get; set; }

        [JsonProperty("end")]
        public virtual string End { get; set; }

        [JsonProperty("thumbnailsIds", NullValueHandling = NullValueHandling.Ignore)]
        public virtual Guid[] ThumbnailsIds { get; set; }

        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public virtual double? Confidence { get; set; }

        [JsonProperty("thumbnailId", NullValueHandling = NullValueHandling.Ignore)]
        public virtual Guid? ThumbnailId { get; set; }
    }

    public partial class Block
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Face
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("confidence")]
        public virtual long Confidence { get; set; }

        [JsonProperty("description")]
        public virtual string Description { get; set; }

        [JsonProperty("thumbnailId")]
        public virtual Guid ThumbnailId { get; set; }

        [JsonProperty("referenceId")]
        public virtual Guid ReferenceId { get; set; }

        [JsonProperty("referenceType")]
        public virtual string ReferenceType { get; set; }

        [JsonProperty("title")]
        public virtual string Title { get; set; }

        [JsonProperty("imageUrl")]
        public virtual Uri ImageUrl { get; set; }

        [JsonProperty("thumbnails")]
        public virtual Thumbnail[] Thumbnails { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Thumbnail
    {
        [JsonProperty("id")]
        public virtual Guid Id { get; set; }

        [JsonProperty("fileName")]
        public virtual string FileName { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Keyword
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("text")]
        public virtual string Text { get; set; }

        [JsonProperty("confidence")]
        public virtual double Confidence { get; set; }

        [JsonProperty("language")]
        public virtual Language Language { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }

        [JsonProperty("speakerId", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? SpeakerId { get; set; }
    }

    public partial class Label
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("language")]
        public virtual Language Language { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Ocr
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("text")]
        public virtual string Text { get; set; }

        [JsonProperty("confidence")]
        public virtual double Confidence { get; set; }

        [JsonProperty("left")]
        public virtual long Left { get; set; }

        [JsonProperty("top")]
        public virtual long Top { get; set; }

        [JsonProperty("width")]
        public virtual long Width { get; set; }

        [JsonProperty("height")]
        public virtual long Height { get; set; }

        [JsonProperty("angle")]
        public virtual long Angle { get; set; }

        [JsonProperty("language")]
        public virtual Language Language { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Sentiment
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("averageScore")]
        public virtual double AverageScore { get; set; }

        [JsonProperty("sentimentType")]
        public virtual string SentimentType { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Shot
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("keyFrames")]
        public virtual Block[] KeyFrames { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Speaker
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }
    }

    public partial class Statistics
    {
        [JsonProperty("correspondenceCount")]
        public virtual long CorrespondenceCount { get; set; }

        [JsonProperty("speakerTalkToListenRatio")]
        public virtual SpeakerLongestMonologClass SpeakerTalkToListenRatio { get; set; }

        [JsonProperty("speakerLongestMonolog")]
        public virtual SpeakerLongestMonologClass SpeakerLongestMonolog { get; set; }

        [JsonProperty("speakerNumberOfFragments")]
        public virtual SpeakerLongestMonologClass SpeakerNumberOfFragments { get; set; }

        [JsonProperty("speakerWordCount")]
        public virtual SpeakerLongestMonologClass SpeakerWordCount { get; set; }
    }

    public partial class SpeakerLongestMonologClass
    {
        [JsonProperty("1")]
        public virtual long The1 { get; set; }
    }

    public partial class TextualContentModeration
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("bannedWordsCount")]
        public virtual long BannedWordsCount { get; set; }

        [JsonProperty("bannedWordsRatio")]
        public virtual long BannedWordsRatio { get; set; }

        [JsonProperty("instances")]
        public virtual object[] Instances { get; set; }
    }

    public partial class Topic
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("referenceId")]
        public virtual string ReferenceId { get; set; }

        [JsonProperty("referenceType")]
        public virtual string ReferenceType { get; set; }

        [JsonProperty("confidence")]
        public virtual double Confidence { get; set; }

        [JsonProperty("iabName")]
        public virtual object IabName { get; set; }

        [JsonProperty("language")]
        public virtual Language Language { get; set; }

        [JsonProperty("instances")]
        public virtual Instance[] Instances { get; set; }

        [JsonProperty("iptcName", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string IptcName { get; set; }
    }

    public partial class VideosRange
    {
        [JsonProperty("videoId")]
        public virtual string VideoId { get; set; }

        [JsonProperty("range")]
        public virtual Range Range { get; set; }
    }

    public partial class Range
    {
        [JsonProperty("start")]
        public virtual string Start { get; set; }

        [JsonProperty("end")]
        public virtual string End { get; set; }
    }

    public enum Language { EnUs };

    public partial class IndexedResult
    {
        public static IndexedResult FromJson(string json) => JsonConvert.DeserializeObject<IndexedResult>(json, WebApplication1.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this IndexedResult self) => JsonConvert.SerializeObject(self, WebApplication1.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                LanguageConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
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
}
