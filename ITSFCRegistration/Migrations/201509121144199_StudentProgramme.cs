namespace ITSFCRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentProgramme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentProgramme",
                c => new
                    {
                        STUDENT_ID = c.String(nullable: false, maxLength: 128),
                        SCHOOL = c.String(),
                        PROGRAMME_CODE = c.String(),
                        PROGRAMME_TITLE = c.String(),
                        STAGE = c.String(),
                        LAST_NAME = c.String(),
                        FIRST_NAME = c.String(),
                        EMAIL_GROUP = c.String(),
                    })
                .PrimaryKey(t => t.STUDENT_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentProgramme");
        }
    }
}
