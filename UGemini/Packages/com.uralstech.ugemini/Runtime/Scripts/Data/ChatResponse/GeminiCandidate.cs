﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Chat
{
    /// <summary>
    /// A response candidate generated from the model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCandidate : IAppendableData<GeminiCandidate>
    {
        /// <summary>
        /// Generated content returned from the model.
        /// </summary>
        public GeminiContent Content;

        /// <summary>
        /// The reason why the model stopped generating tokens.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiFinishReason FinishReason;

        /// <summary>
        /// List of ratings for the safety of a response candidate
        /// There is at most one rating per category.
        /// </summary>
        public GeminiSafetyRating[] SafetyRatings;

        /// <summary>
        /// Citation information for model-generated candidate.
        /// </summary>
        /// <remarks>
        /// This field may be populated with recitation information for any text included in <see cref="Content"/>.<br/>
        /// These are passages that are "recited" from copyrighted material in the foundational LLM's training data.
        /// </remarks>
        public GeminiCitationMetadata CitationMetadata;

        /// <summary>
        /// Token count for this candidate.
        /// </summary>
        public int TokenCount;

        /// <summary>
        /// Attribution information for sources that contributed to a grounded answer.
        /// </summary>
        /// <remarks>
        /// This field is populated for GenerateAnswer calls.
        /// <br/><br/>
        /// Only available in the beta API.
        /// </remarks>
        public GeminiGroundingAttribution GroundingAttributions;

        /// <summary>
        /// Index of the candidate in the list of candidates.
        /// </summary>
        public int Index;

        /// <inheritdoc/>
        public void Append(GeminiCandidate data)
        {
            if (data.Content != null)
                Content.Append(data.Content);

            if (data.FinishReason != default)
                FinishReason = data.FinishReason;

            if (data.SafetyRatings != null)
                SafetyRatings = data.SafetyRatings;

            if (data.CitationMetadata != null)
                CitationMetadata = data.CitationMetadata;

            TokenCount = data.TokenCount;

            if (data.GroundingAttributions != null)
                GroundingAttributions = data.GroundingAttributions;

            Index = data.Index;
        }
    }
}