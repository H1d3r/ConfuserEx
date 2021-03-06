﻿using Confuser.Core;
using Confuser.Renamer.Services;
using dnlib.DotNet;

namespace Confuser.Renamer.References {
	internal class ResourceReference : INameReference<TypeDef> {
		readonly string format;
		readonly Resource resource;
		readonly TypeDef typeDef;

		public ResourceReference(Resource resource, TypeDef typeDef, string format) {
			this.resource = resource;
			this.typeDef = typeDef;
			this.format = format;
		}

		public bool UpdateNameReference(IConfuserContext context, INameService service) {
			resource.Name = string.Format(format, typeDef.ReflectionFullName);
			return true;
		}

		public bool ShouldCancelRename() => false;
	}
}
