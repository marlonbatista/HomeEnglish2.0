using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Shared.Interfaces
{
    
    public interface IBaseEntity
    {
        String Uid { get; set; }
        DateTime CreateDate { get; set; }
        DateTime ModifyDate { get; set; }

    }
}
