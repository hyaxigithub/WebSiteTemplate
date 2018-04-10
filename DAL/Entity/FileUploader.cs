namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileUploader")]
    public partial class FileUploader
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(36)]
        public string Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Path { get; set; }

        [StringLength(500)]
        public string FullPath { get; set; }

        [StringLength(200)]
        public string Suffix { get; set; }

        public int? Size { get; set; }

        [StringLength(4000)]
        public string Remark { get; set; }

        [StringLength(200)]
        public string State { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(200)]
        public string CreatePerson { get; set; }
    }
}
