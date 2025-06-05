-- 1. Stored Procedures – Insert Data
use EventDb
CREATE PROCEDURE UserInfo_Insert
    @EmailId VARCHAR(100),
    @UserName VARCHAR(50),
    @Role VARCHAR(20),
    @Password VARCHAR(20)
AS
BEGIN
    INSERT INTO UserInfo (EmailId, UserName, Role, Password)
    VALUES (@EmailId, @UserName, @Role, @Password);
END

-- 2. Stored Procedures – Delete Data (by primary key)
CREATE PROCEDURE UserInfo_Delete
    @EmailId VARCHAR(100)
AS
BEGIN
    DELETE FROM UserInfo WHERE EmailId = @EmailId;
END

-- 3. Stored Procedures – Update Data (by primary key)
CREATE PROCEDURE UserInfo_Update
    @EmailId VARCHAR(100),
    @UserName VARCHAR(50),
    @Role VARCHAR(20),
    @Password VARCHAR(20)
AS
BEGIN
    UPDATE UserInfo
    SET UserName = @UserName,
        Role = @Role,
        Password = @Password
    WHERE EmailId = @EmailId;
END

-- 4. View: Session Details of a Particular Event
CREATE VIEW View_SessionDetails_ByEvent
AS
SELECT 
    s.SessionId,
    s.EventId,
    e.EventName,
    s.SessionTitle,
    s.SpeakerId,
    s.SessionStart,
    s.SessionEnd,
    s.SessionUrl
FROM 
    SessionInfo s
JOIN 
    EventDetails e ON s.EventId = e.EventId;

-- 5. View: Speaker Detail of Particular Session
CREATE VIEW View_SpeakerDetails_BySession
AS
SELECT 
    s.SessionId,
    sp.SpeakerId,
    sp.SpeakerName,
    s.SessionTitle,
    s.SessionStart,
    s.SessionEnd
FROM 
    SessionInfo s
JOIN 
    SpeakersDetails sp ON s.SpeakerId = sp.SpeakerId;

-- 6. View: Full Event Details (Sessions + Speakers + Participants)
CREATE VIEW View_FullEventDetails
AS
SELECT 
    e.EventId,
    e.EventName,
    e.EventCategory,
    e.EventDate,
    s.SessionId,
    s.SessionTitle,
    sp.SpeakerName,
    p.ParticipantEmailId,
    u.UserName AS ParticipantName,
    p.IsAttended
FROM 
    EventDetails e
JOIN 
    SessionInfo s ON e.EventId = s.EventId
JOIN 
    SpeakersDetails sp ON s.SpeakerId = sp.SpeakerId
JOIN 
    ParticipantEventDetails p ON s.SessionId = p.SessionId
JOIN 
    UserInfo u ON p.ParticipantEmailId = u.EmailId;

-- 7. Apply Non-Clustered Indexes
-- On EmailId (used in WHERE and JOIN)
CREATE NONCLUSTERED INDEX IX_UserInfo_EmailId ON UserInfo(EmailId);

-- On EventId in SessionInfo
CREATE NONCLUSTERED INDEX IX_SessionInfo_EventId ON SessionInfo(EventId);

-- On SpeakerId in SessionInfo
CREATE NONCLUSTERED INDEX IX_SessionInfo_SpeakerId ON SessionInfo(SpeakerId);

-- On SessionId in ParticipantEventDetails
CREATE NONCLUSTERED INDEX IX_ParticipantEventDetails_SessionId ON ParticipantEventDetails(SessionId);

-- On ParticipantEmailId for fast lookup
CREATE NONCLUSTERED INDEX IX_ParticipantEventDetails_Email ON ParticipantEventDetails(ParticipantEmailId);

