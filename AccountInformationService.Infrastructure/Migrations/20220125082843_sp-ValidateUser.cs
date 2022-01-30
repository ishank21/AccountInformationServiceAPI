using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountInformationService.Infrastructure.Migrations
{
    public partial class spValidateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SP_ValidateUserIdForClient_AccountDetails]
                         @IsClientEndPoint BIT,
                         @TokenID NVARCHAR(100),
                         @Id NVARCHAR(100)
                     AS
                     BEGIN 
                     SELECT case WHEN @IsClientEndPoint = 1 
                                       THEN 
                                           CASE WHEN EXISTS(
                                                   Select TOP 1 ClientID FROM Client_Detail WHERE UserID = @TokenID AND ClientID = @Id
                                              ) THEN 1 ELSE 0
                                           END
                     					  ELSE
                     					  CASE WHEN EXISTS(
                                                  Select TOP 1 AccoundId FROM ClientAccount_Detail WHERE UserID = @TokenID AND AccoundId = @Id
                                              ) THEN 1 ELSE 0
                                           END
                     					  
                            END
                     END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
