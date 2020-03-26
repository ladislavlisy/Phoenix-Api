/*
 * Phoenix Payroll API
 *
 * design and build great web apis
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Employee : IEquatable<Employee>
    { 
        /// <summary>
        /// Gets or Sets EmployeeIdentifier
        /// </summary>
        [DataMember(Name="employeeIdentifier")]
        public decimal? EmployeeIdentifier { get; set; }

        /// <summary>
        /// Gets or Sets PersonCode
        /// </summary>
        [DataMember(Name="person-code")]
        public string PersonCode { get; set; }

        /// <summary>
        /// Gets or Sets GivenName
        /// </summary>
        [DataMember(Name="given-name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or Sets FamilyName
        /// </summary>
        [DataMember(Name="family-name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Contract
        /// </summary>
        [DataMember(Name="contract")]
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [DataMember(Name="position")]
        public Position Position { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Employee {\n");
            sb.Append("  EmployeeIdentifier: ").Append(EmployeeIdentifier).Append("\n");
            sb.Append("  PersonCode: ").Append(PersonCode).Append("\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  FamilyName: ").Append(FamilyName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Employee)obj);
        }

        /// <summary>
        /// Returns true if Employee instances are equal
        /// </summary>
        /// <param name="other">Instance of Employee to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Employee other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    EmployeeIdentifier == other.EmployeeIdentifier ||
                    EmployeeIdentifier != null &&
                    EmployeeIdentifier.Equals(other.EmployeeIdentifier)
                ) && 
                (
                    PersonCode == other.PersonCode ||
                    PersonCode != null &&
                    PersonCode.Equals(other.PersonCode)
                ) && 
                (
                    GivenName == other.GivenName ||
                    GivenName != null &&
                    GivenName.Equals(other.GivenName)
                ) && 
                (
                    FamilyName == other.FamilyName ||
                    FamilyName != null &&
                    FamilyName.Equals(other.FamilyName)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Contract == other.Contract ||
                    Contract != null &&
                    Contract.Equals(other.Contract)
                ) && 
                (
                    Position == other.Position ||
                    Position != null &&
                    Position.Equals(other.Position)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (EmployeeIdentifier != null)
                    hashCode = hashCode * 59 + EmployeeIdentifier.GetHashCode();
                    if (PersonCode != null)
                    hashCode = hashCode * 59 + PersonCode.GetHashCode();
                    if (GivenName != null)
                    hashCode = hashCode * 59 + GivenName.GetHashCode();
                    if (FamilyName != null)
                    hashCode = hashCode * 59 + FamilyName.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Contract != null)
                    hashCode = hashCode * 59 + Contract.GetHashCode();
                    if (Position != null)
                    hashCode = hashCode * 59 + Position.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Employee left, Employee right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Employee left, Employee right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}