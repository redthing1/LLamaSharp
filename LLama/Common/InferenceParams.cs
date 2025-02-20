﻿using LLama.Abstractions;
using System;
using System.Collections.Generic;
using LLama.Native;

namespace LLama.Common
{
    using llama_token = Int32;
    /// <summary>
    /// The paramters used for inference.
    /// </summary>
    public class InferenceParams : IInferenceParams
    {
        /// <summary>
        /// number of tokens to keep from initial prompt
        /// </summary>
        public int TokensKeep { get; set; } = 0;
        /// <summary>
        /// how many new tokens to predict (n_predict), set to -1 to inifinitely generate response
        /// until it complete.
        /// </summary>
        public int MaxTokens { get; set; } = -1;
        /// <summary>
        /// logit bias for specific tokens
        /// </summary>
        public Dictionary<llama_token, float>? LogitBias { get; set; } = null;

        /// <summary>
        /// Sequences where the model will stop generating further tokens.
        /// </summary>
        public IEnumerable<string> AntiPrompts { get; set; } = Array.Empty<string>();

        /// <summary>
        ///  0 or lower to use vocab size
        /// </summary>
        public int TopK { get; set; } = 40;
        /// <summary>
        /// 1.0 = disabled
        /// </summary>
        public float TopP { get; set; } = 0.95f;
        /// <summary>
        /// 1.0 = disabled
        /// </summary>
        public float TfsZ { get; set; } = 1.0f;
        /// <summary>
        /// 1.0 = disabled
        /// </summary>
        public float TypicalP { get; set; } = 1.0f;
        /// <summary>
        /// 1.0 = disabled
        /// </summary>
        public float Temperature { get; set; } = 0.8f;
        /// <summary>
        /// 1.0 = disabled
        /// </summary>
        public float RepeatPenalty { get; set; } = 1.1f;
        /// <summary>
        /// last n tokens to penalize (0 = disable penalty, -1 = context size) (repeat_last_n)
        /// </summary>
        public int RepeatLastTokensCount { get; set; } = 64;
        /// <summary>
        /// frequency penalty coefficient
        /// 0.0 = disabled
        /// </summary>
        public float FrequencyPenalty { get; set; } = .0f;
        /// <summary>
        /// presence penalty coefficient
        /// 0.0 = disabled
        /// </summary>
        public float PresencePenalty { get; set; } = .0f;
        /// <summary>
        /// Mirostat uses tokens instead of words.
        /// algorithm described in the paper https://arxiv.org/abs/2007.14966.
        /// 0 = disabled, 1 = mirostat, 2 = mirostat 2.0
        /// </summary>
        public MirostatType Mirostat { get; set; } = MirostatType.Disable;
        /// <summary>
        /// target entropy
        /// </summary>
        public float MirostatTau { get; set; } = 5.0f;
        /// <summary>
        /// learning rate
        /// </summary>
        public float MirostatEta { get; set; } = 0.1f;
        /// <summary>
        /// consider newlines as a repeatable token (penalize_nl)
        /// </summary>
        public bool PenalizeNL { get; set; } = true;

        /// <summary>
        /// A grammar to constrain the possible tokens
        /// </summary>
        public SafeLLamaGrammarHandle? Grammar { get; set; }
    }

    /// <summary>
    /// Type of "mirostat" sampling to use.
    /// https://github.com/basusourya/mirostat
    /// </summary>
    public enum MirostatType
    {
        /// <summary>
        /// Disable Mirostat sampling
        /// </summary>
        Disable = 0,

        /// <summary>
        /// Original mirostat algorithm
        /// </summary>
        Mirostat = 1,

        /// <summary>
        /// Mirostat 2.0 algorithm
        /// </summary>
        Mirostat2 = 2
    }
}
