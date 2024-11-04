using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoranMedia.Infrastructure.Migrations
{
    public partial class EntitiesRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignClient_Campaigns_CampaignsCampaignID",
                table: "CampaignClient");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignClient_Clients_ClientsClientID",
                table: "CampaignClient");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Templates_TemplateID",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_TemplateID",
                table: "Campaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampaignClient",
                table: "CampaignClient");

            migrationBuilder.RenameTable(
                name: "CampaignClient",
                newName: "ClientCampaigns");

            migrationBuilder.RenameColumn(
                name: "TemplateID",
                table: "Campaigns",
                newName: "TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_CampaignClient_ClientsClientID",
                table: "ClientCampaigns",
                newName: "IX_ClientCampaigns_ClientsClientID");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCampaigns",
                table: "ClientCampaigns",
                columns: new[] { "CampaignsCampaignID", "ClientsClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_CampaignId",
                table: "Emails",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_TemplateId",
                table: "Campaigns",
                column: "TemplateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Templates_TemplateId",
                table: "Campaigns",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "TemplateID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCampaigns_Campaigns_CampaignsCampaignID",
                table: "ClientCampaigns",
                column: "CampaignsCampaignID",
                principalTable: "Campaigns",
                principalColumn: "CampaignID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCampaigns_Clients_ClientsClientID",
                table: "ClientCampaigns",
                column: "ClientsClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Campaigns_CampaignId",
                table: "Emails",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "CampaignID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Templates_TemplateId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCampaigns_Campaigns_CampaignsCampaignID",
                table: "ClientCampaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCampaigns_Clients_ClientsClientID",
                table: "ClientCampaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Campaigns_CampaignId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_CampaignId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_TemplateId",
                table: "Campaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCampaigns",
                table: "ClientCampaigns");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Emails");

            migrationBuilder.RenameTable(
                name: "ClientCampaigns",
                newName: "CampaignClient");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "Campaigns",
                newName: "TemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCampaigns_ClientsClientID",
                table: "CampaignClient",
                newName: "IX_CampaignClient_ClientsClientID");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Emails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampaignClient",
                table: "CampaignClient",
                columns: new[] { "CampaignsCampaignID", "ClientsClientID" });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_TemplateID",
                table: "Campaigns",
                column: "TemplateID");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignClient_Campaigns_CampaignsCampaignID",
                table: "CampaignClient",
                column: "CampaignsCampaignID",
                principalTable: "Campaigns",
                principalColumn: "CampaignID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignClient_Clients_ClientsClientID",
                table: "CampaignClient",
                column: "ClientsClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Templates_TemplateID",
                table: "Campaigns",
                column: "TemplateID",
                principalTable: "Templates",
                principalColumn: "TemplateID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
