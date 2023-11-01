﻿using Framework.Core.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherZapto.Data.Entities
{
    [Table("Logs")]
    public class LogsEntity : ItemEntity
    {
        [MaxLength(128)] public string Timestamp { get; set; } = string.Empty;
        [MaxLength(64)] public string Level { get; set; } = string.Empty;
        [MaxLength(128)] public string Exception { get; set; } = string.Empty;
        [MaxLength(128)] public string RenderedMessage { get; set; } = string.Empty;
        [MaxLength(128)] public string Properties { get; set; } = string.Empty;
    }
}
