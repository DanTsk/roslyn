﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.EditAndContinue
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal readonly struct NonRemappableRegion
    {
        /// <summary>
        /// Pre-remap span.
        /// </summary>
        public readonly LinePositionSpan Span;

        /// <summary>
        /// Difference between new span and pre-remap span (new = old + delta).
        /// </summary>
        public readonly int LineDelta;

        /// <summary>
        /// True if the region represents an exception region, false if it represents an active statement.
        /// </summary>
        public readonly bool IsExceptionRegion;

        public NonRemappableRegion(LinePositionSpan span, int lineDelta, bool isExceptionRegion)
        {
            Span = span;
            LineDelta = lineDelta;
            IsExceptionRegion = isExceptionRegion;
        }

        public NonRemappableRegion WithLineDelta(int value)
            => new NonRemappableRegion(Span, value, IsExceptionRegion);

        internal string GetDebuggerDisplay()
            => $"{(IsExceptionRegion ? "ER" : "AS")} {Span} δ={LineDelta}";
    }
}
