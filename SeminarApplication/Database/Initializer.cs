using Dapper;

namespace SeminarApplication.Database;

public class Initializer
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public Initializer(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    
    public async Task InitializeAsync()
    {
        await AddParticipantTableAsync();
        await AddSeminarTableAsync();
        await AddCourseTableAsync();
        await AddSeminarCourseTableAsync();
        await AddCourseParticipantTableAsync();
        
        // For demo purposes
        await InsertDemoDataAsync();
    }

    private async Task AddParticipantTableAsync()
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"IF OBJECT_ID(N'dbo.Participant', N'U') IS NULL 
			BEGIN
				CREATE TABLE Participant (
	            Id INT NOT NULL PRIMARY KEY IDENTITY,
	            FirstName NVARCHAR(100) NOT NULL,
	            LastName NVARCHAR(100) NOT NULL,
	            EmailAddress NVARCHAR(255) NOT NULL,
				DeletedDate DATETIME NULL);
			END;
        ");
    }
    
    private async Task AddSeminarTableAsync()
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"IF OBJECT_ID(N'dbo.Seminar', N'U') IS NULL
			BEGIN
				CREATE TABLE Seminar (
	            Id INT NOT NULL PRIMARY KEY IDENTITY,
	            SeminarName NVARCHAR(100) NOT NULL,
	            StartDate DATETIME NOT NULL,
	            EndDate DATETIME NOT NULL,
				DeletedDate DATETIME NULL);
			END;
        ");
    }

    private async Task AddCourseTableAsync()
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"IF OBJECT_ID(N'dbo.Course', N'U') IS NULL
			BEGIN
				CREATE TABLE Course (
	            Id INT NOT NULL PRIMARY KEY IDENTITY,
	            CourseName NVARCHAR(100) NOT NULL,
				InstructorFirstName NVARCHAR(100) NOT NULL,
	            InstructorLastName NVARCHAR(100) NOT NULL,
	            RoomName NVARCHAR(100) NOT NULL,
	            StartDate DATETIME NOT NULL,
	            EndDate DATETIME NOT NULL,
				DeletedDate DATETIME NULL);
			END;
        ");
    }
    
    private async Task AddSeminarCourseTableAsync()
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"IF OBJECT_ID(N'dbo.SeminarCourse', N'U') IS NULL
			BEGIN
				CREATE TABLE SeminarCourse (
	            SeminarId INT NOT NULL, 
	            CourseId INT NOT NULL,
	            CONSTRAINT PK_SeminarCourse PRIMARY KEY (SeminarId, CourseId),
		        CONSTRAINT FK_SeminarCourse_Seminar FOREIGN KEY (SeminarId) REFERENCES Seminar(Id), 
	            CONSTRAINT FK_SeminarCourse_Course FOREIGN KEY (CourseId) REFERENCES Course(Id));
			END;
        ");
    }

    private async Task AddCourseParticipantTableAsync()
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"IF OBJECT_ID(N'dbo.CourseParticipant', N'U') IS NULL
			BEGIN
				CREATE TABLE CourseParticipant (
	            CourseId INT NOT NULL,
		        ParticipantId INT NOT NULL,
		        CONSTRAINT PK_CourseParticipant PRIMARY KEY (CourseId, ParticipantId),
		        CONSTRAINT FK_CourseParticipant_Course FOREIGN KEY (CourseId) REFERENCES Course(Id), 
	            CONSTRAINT FK_CourseParticipant_User FOREIGN KEY (ParticipantId) REFERENCES Participant(Id));
			END;
        ");
    }

    private async Task InsertDemoDataAsync()
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"IF NOT EXISTS (SELECT 1 FROM Participant)
			BEGIN
				INSERT INTO Participant (FirstName, LastName, EmailAddress)
				VALUES 
				('Participant', 'One', 'participant1@testseminar.com'),
				('Participant', 'Two', 'participant2@testseminar.com'),
				('Participant', 'Three', 'participant3@testseminar.com');

				INSERT INTO Seminar (SeminarName, StartDate, EndDate)
				VALUES 
				('Seminar', CAST('20221001 09:00:00' AS datetime), CAST('20221003 17:00:00' AS datetime));

				INSERT INTO Course (CourseName, InstructorFirstName, InstructorLastName, RoomName, StartDate, EndDate)
				VALUES 
				('Course-One', 'Instructor', 'One', 'First-Room', CAST('20221001 09:00:00' AS datetime), CAST('20221001 10:00:00' AS datetime)),
				('Course-Two', 'Instructor', 'Two', 'Second-Room', CAST('20221002 09:00:00' AS datetime), CAST('20221002 10:00:00' AS datetime)),
				('Course-Three', 'Instructor', 'One', 'First-Room', CAST('20221003 09:00:00' AS datetime), CAST('20221003 10:00:00' AS datetime));

				INSERT INTO SeminarCourse (SeminarId, CourseId)
				VALUES 
				(1, 1),
				(1, 2),
				(1, 3);

				INSERT INTO CourseParticipant (CourseId, ParticipantId)
				VALUES 
				(1, 1),
				(1, 2),
				(1, 3),
				(2, 1),
				(2, 3),
				(3, 2);
			END
        ");
    }
}