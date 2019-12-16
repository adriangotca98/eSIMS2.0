namespace eSims.Models
{
	public class eSimsDatabaseSettings : IeSimsDatabaseSettings
	{
		public string ProfessorsCollectionName { get; set; }
		public string StudentsCollectionName { get; set; }
		public string GradesCollectionName { get; set; }
		public string SubjectsCollectionName { get; set; }
		public string AttendanceCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}

	public interface IeSimsDatabaseSettings
	{
		public string ProfessorsCollectionName { get; set; }
		public string StudentsCollectionName { get; set; }
		public string GradesCollectionName { get; set; }
		public string SubjectsCollectionName { get; set; }
		public string AttendanceCollectionName { get; set; }
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
