﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Paymatic
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Paymatic")]
	public partial class PaymaticDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttbl_TimesheetRawNew(tbl_TimesheetRawNew instance);
    partial void Updatetbl_TimesheetRawNew(tbl_TimesheetRawNew instance);
    partial void Deletetbl_TimesheetRawNew(tbl_TimesheetRawNew instance);
    partial void Inserttbl_TimeSheet(tbl_TimeSheet instance);
    partial void Updatetbl_TimeSheet(tbl_TimeSheet instance);
    partial void Deletetbl_TimeSheet(tbl_TimeSheet instance);
    #endregion
		
		public PaymaticDataContext() : 
				base(global::Paymatic.Properties.Settings.Default.PaymaticConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PaymaticDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PaymaticDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PaymaticDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PaymaticDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbl_TimesheetRawNew> tbl_TimesheetRawNews
		{
			get
			{
				return this.GetTable<tbl_TimesheetRawNew>();
			}
		}
		
		public System.Data.Linq.Table<tbl_TimeSheet> tbl_TimeSheets
		{
			get
			{
				return this.GetTable<tbl_TimeSheet>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_TimesheetRawNew")]
	public partial class tbl_TimesheetRawNew : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TimeSheetRawID;
		
		private string _UserId;
		
		private string _Name;
		
		private System.Nullable<int> _Shift;
		
		private System.Nullable<System.DateTime> _Punch;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTimeSheetRawIDChanging(int value);
    partial void OnTimeSheetRawIDChanged();
    partial void OnUserIdChanging(string value);
    partial void OnUserIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnShiftChanging(System.Nullable<int> value);
    partial void OnShiftChanged();
    partial void OnPunchChanging(System.Nullable<System.DateTime> value);
    partial void OnPunchChanged();
    #endregion
		
		public tbl_TimesheetRawNew()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeSheetRawID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TimeSheetRawID
		{
			get
			{
				return this._TimeSheetRawID;
			}
			set
			{
				if ((this._TimeSheetRawID != value))
				{
					this.OnTimeSheetRawIDChanging(value);
					this.SendPropertyChanging();
					this._TimeSheetRawID = value;
					this.SendPropertyChanged("TimeSheetRawID");
					this.OnTimeSheetRawIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="NVarChar(10)")]
		public string UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Shift", DbType="Int")]
		public System.Nullable<int> Shift
		{
			get
			{
				return this._Shift;
			}
			set
			{
				if ((this._Shift != value))
				{
					this.OnShiftChanging(value);
					this.SendPropertyChanging();
					this._Shift = value;
					this.SendPropertyChanged("Shift");
					this.OnShiftChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Punch", DbType="DateTime")]
		public System.Nullable<System.DateTime> Punch
		{
			get
			{
				return this._Punch;
			}
			set
			{
				if ((this._Punch != value))
				{
					this.OnPunchChanging(value);
					this.SendPropertyChanging();
					this._Punch = value;
					this.SendPropertyChanged("Punch");
					this.OnPunchChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_TimeSheet")]
	public partial class tbl_TimeSheet : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TimeSheetID;
		
		private string _UserID;
		
		private System.Nullable<System.DateTime> _Date;
		
		private System.Nullable<System.DateTime> _TimeIn;
		
		private System.Nullable<System.DateTime> _BreakOut;
		
		private System.Nullable<System.DateTime> _Resume;
		
		private System.Nullable<System.DateTime> _Out;
		
		private System.Nullable<System.DateTime> _OT;
		
		private System.Nullable<System.DateTime> _Done;
		
		private System.Nullable<decimal> _HoursWork;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTimeSheetIDChanging(int value);
    partial void OnTimeSheetIDChanged();
    partial void OnUserIDChanging(string value);
    partial void OnUserIDChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnTimeInChanging(System.Nullable<System.DateTime> value);
    partial void OnTimeInChanged();
    partial void OnBreakOutChanging(System.Nullable<System.DateTime> value);
    partial void OnBreakOutChanged();
    partial void OnResumeChanging(System.Nullable<System.DateTime> value);
    partial void OnResumeChanged();
    partial void OnOutChanging(System.Nullable<System.DateTime> value);
    partial void OnOutChanged();
    partial void OnOTChanging(System.Nullable<System.DateTime> value);
    partial void OnOTChanged();
    partial void OnDoneChanging(System.Nullable<System.DateTime> value);
    partial void OnDoneChanged();
    partial void OnHoursWorkChanging(System.Nullable<decimal> value);
    partial void OnHoursWorkChanged();
    #endregion
		
		public tbl_TimeSheet()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeSheetID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TimeSheetID
		{
			get
			{
				return this._TimeSheetID;
			}
			set
			{
				if ((this._TimeSheetID != value))
				{
					this.OnTimeSheetIDChanging(value);
					this.SendPropertyChanging();
					this._TimeSheetID = value;
					this.SendPropertyChanged("TimeSheetID");
					this.OnTimeSheetIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="NVarChar(10)")]
		public string UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeIn", DbType="DateTime")]
		public System.Nullable<System.DateTime> TimeIn
		{
			get
			{
				return this._TimeIn;
			}
			set
			{
				if ((this._TimeIn != value))
				{
					this.OnTimeInChanging(value);
					this.SendPropertyChanging();
					this._TimeIn = value;
					this.SendPropertyChanged("TimeIn");
					this.OnTimeInChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BreakOut", DbType="DateTime")]
		public System.Nullable<System.DateTime> BreakOut
		{
			get
			{
				return this._BreakOut;
			}
			set
			{
				if ((this._BreakOut != value))
				{
					this.OnBreakOutChanging(value);
					this.SendPropertyChanging();
					this._BreakOut = value;
					this.SendPropertyChanged("BreakOut");
					this.OnBreakOutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Resume", DbType="DateTime")]
		public System.Nullable<System.DateTime> Resume
		{
			get
			{
				return this._Resume;
			}
			set
			{
				if ((this._Resume != value))
				{
					this.OnResumeChanging(value);
					this.SendPropertyChanging();
					this._Resume = value;
					this.SendPropertyChanged("Resume");
					this.OnResumeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Out", DbType="DateTime")]
		public System.Nullable<System.DateTime> Out
		{
			get
			{
				return this._Out;
			}
			set
			{
				if ((this._Out != value))
				{
					this.OnOutChanging(value);
					this.SendPropertyChanging();
					this._Out = value;
					this.SendPropertyChanged("Out");
					this.OnOutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OT", DbType="DateTime")]
		public System.Nullable<System.DateTime> OT
		{
			get
			{
				return this._OT;
			}
			set
			{
				if ((this._OT != value))
				{
					this.OnOTChanging(value);
					this.SendPropertyChanging();
					this._OT = value;
					this.SendPropertyChanged("OT");
					this.OnOTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Done", DbType="DateTime")]
		public System.Nullable<System.DateTime> Done
		{
			get
			{
				return this._Done;
			}
			set
			{
				if ((this._Done != value))
				{
					this.OnDoneChanging(value);
					this.SendPropertyChanging();
					this._Done = value;
					this.SendPropertyChanged("Done");
					this.OnDoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoursWork", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> HoursWork
		{
			get
			{
				return this._HoursWork;
			}
			set
			{
				if ((this._HoursWork != value))
				{
					this.OnHoursWorkChanging(value);
					this.SendPropertyChanging();
					this._HoursWork = value;
					this.SendPropertyChanged("HoursWork");
					this.OnHoursWorkChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591