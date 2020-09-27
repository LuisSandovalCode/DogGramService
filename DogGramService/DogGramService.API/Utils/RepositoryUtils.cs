using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGramService.API.Utils
{
    public static class RepositoryUtils
    {
        public static ObjectId GetInternalId(this string id)
        {
            if (ObjectId.TryParse(id, out ObjectId internalId))
                return internalId;
            else
                return ObjectId.Empty;
        }
    }
}
