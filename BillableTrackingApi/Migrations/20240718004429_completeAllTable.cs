using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillableTrackingApi.Migrations
{
    /// <inheritdoc />
    public partial class completeAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    Address2 = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    PostCode = table.Column<string>(type: "text", nullable: false),
                    ABN = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReferralSources",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    Address2 = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Postcode = table.Column<string>(type: "text", nullable: false),
                    ProviderNumber = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    ABN = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralSources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRecord",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    ApprovedUserDeviceName = table.Column<string>(type: "text", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecord", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BillableItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    InsuranceCompanyID = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ItemPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillableItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillableItems_InsuranceCompanies_InsuranceCompanyID",
                        column: x => x.InsuranceCompanyID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalRecord",
                columns: table => new
                {
                    HospitalID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderNumber = table.Column<string>(type: "text", nullable: false),
                    LSPN = table.Column<string>(type: "text", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalRecord", x => x.HospitalID);
                    table.ForeignKey(
                        name: "FK_HospitalRecord_UserRecord_UserID",
                        column: x => x.UserID,
                        principalTable: "UserRecord",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Middle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    InsuranceCompanyID = table.Column<Guid>(type: "uuid", nullable: false),
                    InsuranceMemberNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MedicareNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Address1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReferralID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReferralDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HospitalID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_HospitalRecord_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "HospitalRecord",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_InsuranceCompanies_InsuranceCompanyID",
                        column: x => x.InsuranceCompanyID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_ReferralSources_ReferralID",
                        column: x => x.ReferralID,
                        principalTable: "ReferralSources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillableItemEvents",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientID = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    SelectedItemID = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectedItemCurrentPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Invoiced = table.Column<bool>(type: "boolean", nullable: false),
                    InvoiceID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillableItemEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillableItemEvents_BillableItems_SelectedItemID",
                        column: x => x.SelectedItemID,
                        principalTable: "BillableItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillableItemEvents_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillableItemEvents_PatientID",
                table: "BillableItemEvents",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_BillableItemEvents_SelectedItemID",
                table: "BillableItemEvents",
                column: "SelectedItemID");

            migrationBuilder.CreateIndex(
                name: "IX_BillableItems_InsuranceCompanyID",
                table: "BillableItems",
                column: "InsuranceCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRecord_UserID",
                table: "HospitalRecord",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalID",
                table: "Patients",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InsuranceCompanyID",
                table: "Patients",
                column: "InsuranceCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ReferralID",
                table: "Patients",
                column: "ReferralID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillableItemEvents");

            migrationBuilder.DropTable(
                name: "BillableItems");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "HospitalRecord");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "ReferralSources");

            migrationBuilder.DropTable(
                name: "UserRecord");
        }
    }
}
