﻿#region (c) 2010-2011 Lokad - CQRS for Windows Azure - New BSD License 

// Copyright (c) Lokad 2010-2011, http://www.lokad.com
// This code is released as Open Source under the terms of the New BSD Licence

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Lokad.Cqrs.Core.Directory;
using Lokad.Cqrs.Evil;

namespace Lokad.Cqrs.Core.Dispatch
{
	static class MessageDispatch
	{
		public const string UnitOfWorkTag = "UnitOfWork";
		public const string ScopeTag = "Scope";

		public static void ThrowIfCommandHasMultipleConsumers(IEnumerable<MessageInfo> commands)
		{
			var multipleConsumers = commands
				.Where(c => c.AllConsumers.Length > 1)
				.Select(c => c.MessageType.FullName);

			if (multipleConsumers.Any())
			{
				throw new InvalidOperationException(
					"These messages have multiple consumers. Did you intend to declare them as events? " +
						multipleConsumers.JoinStrings(Environment.NewLine));
			}
		}
	}
}