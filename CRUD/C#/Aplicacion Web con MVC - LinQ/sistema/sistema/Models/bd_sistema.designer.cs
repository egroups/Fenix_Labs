﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.17929
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sistema.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="sistema")]
	public partial class bd_sistemaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void Insertproductos(productos instance);
    partial void Updateproductos(productos instance);
    partial void Deleteproductos(productos instance);
    partial void Insertproveedores(proveedores instance);
    partial void Updateproveedores(proveedores instance);
    partial void Deleteproveedores(proveedores instance);
    partial void Insertusuarios(usuarios instance);
    partial void Updateusuarios(usuarios instance);
    partial void Deleteusuarios(usuarios instance);
    #endregion
		
		public bd_sistemaDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["sistemaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public bd_sistemaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bd_sistemaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bd_sistemaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bd_sistemaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<productos> productos
		{
			get
			{
				return this.GetTable<productos>();
			}
		}
		
		public System.Data.Linq.Table<proveedores> proveedores
		{
			get
			{
				return this.GetTable<proveedores>();
			}
		}
		
		public System.Data.Linq.Table<usuarios> usuarios
		{
			get
			{
				return this.GetTable<usuarios>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.productos")]
	public partial class productos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_producto;
		
		private string _nombre_producto;
		
		private string _descripcion;
		
		private System.Nullable<int> _precio;
		
		private System.Nullable<int> _id_proveedor;
		
		private string _fecha_registro;
		
		private EntityRef<proveedores> _proveedores;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_productoChanging(int value);
    partial void Onid_productoChanged();
    partial void Onnombre_productoChanging(string value);
    partial void Onnombre_productoChanged();
    partial void OndescripcionChanging(string value);
    partial void OndescripcionChanged();
    partial void OnprecioChanging(System.Nullable<int> value);
    partial void OnprecioChanged();
    partial void Onid_proveedorChanging(System.Nullable<int> value);
    partial void Onid_proveedorChanged();
    partial void Onfecha_registroChanging(string value);
    partial void Onfecha_registroChanged();
    #endregion
		
		public productos()
		{
			this._proveedores = default(EntityRef<proveedores>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_producto", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_producto
		{
			get
			{
				return this._id_producto;
			}
			set
			{
				if ((this._id_producto != value))
				{
					this.Onid_productoChanging(value);
					this.SendPropertyChanging();
					this._id_producto = value;
					this.SendPropertyChanged("id_producto");
					this.Onid_productoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre_producto", DbType="NVarChar(100)")]
		public string nombre_producto
		{
			get
			{
				return this._nombre_producto;
			}
			set
			{
				if ((this._nombre_producto != value))
				{
					this.Onnombre_productoChanging(value);
					this.SendPropertyChanging();
					this._nombre_producto = value;
					this.SendPropertyChanged("nombre_producto");
					this.Onnombre_productoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcion", DbType="NVarChar(100)")]
		public string descripcion
		{
			get
			{
				return this._descripcion;
			}
			set
			{
				if ((this._descripcion != value))
				{
					this.OndescripcionChanging(value);
					this.SendPropertyChanging();
					this._descripcion = value;
					this.SendPropertyChanged("descripcion");
					this.OndescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_precio", DbType="Int")]
		public System.Nullable<int> precio
		{
			get
			{
				return this._precio;
			}
			set
			{
				if ((this._precio != value))
				{
					this.OnprecioChanging(value);
					this.SendPropertyChanging();
					this._precio = value;
					this.SendPropertyChanged("precio");
					this.OnprecioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_proveedor", DbType="Int")]
		public System.Nullable<int> id_proveedor
		{
			get
			{
				return this._id_proveedor;
			}
			set
			{
				if ((this._id_proveedor != value))
				{
					if (this._proveedores.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_proveedorChanging(value);
					this.SendPropertyChanging();
					this._id_proveedor = value;
					this.SendPropertyChanged("id_proveedor");
					this.Onid_proveedorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_registro", DbType="NVarChar(100)")]
		public string fecha_registro
		{
			get
			{
				return this._fecha_registro;
			}
			set
			{
				if ((this._fecha_registro != value))
				{
					this.Onfecha_registroChanging(value);
					this.SendPropertyChanging();
					this._fecha_registro = value;
					this.SendPropertyChanged("fecha_registro");
					this.Onfecha_registroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="proveedores_productos", Storage="_proveedores", ThisKey="id_proveedor", OtherKey="id_proveedor", IsForeignKey=true)]
		public proveedores proveedores
		{
			get
			{
				return this._proveedores.Entity;
			}
			set
			{
				proveedores previousValue = this._proveedores.Entity;
				if (((previousValue != value) 
							|| (this._proveedores.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._proveedores.Entity = null;
						previousValue.productos.Remove(this);
					}
					this._proveedores.Entity = value;
					if ((value != null))
					{
						value.productos.Add(this);
						this._id_proveedor = value.id_proveedor;
					}
					else
					{
						this._id_proveedor = default(Nullable<int>);
					}
					this.SendPropertyChanged("proveedores");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.proveedores")]
	public partial class proveedores : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_proveedor;
		
		private string _nombre_empresa;
		
		private string _direccion;
		
		private System.Nullable<int> _telefono;
		
		private string _fecha_registro_proveedor;
		
		private EntitySet<productos> _productos;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_proveedorChanging(int value);
    partial void Onid_proveedorChanged();
    partial void Onnombre_empresaChanging(string value);
    partial void Onnombre_empresaChanged();
    partial void OndireccionChanging(string value);
    partial void OndireccionChanged();
    partial void OntelefonoChanging(System.Nullable<int> value);
    partial void OntelefonoChanged();
    partial void Onfecha_registro_proveedorChanging(string value);
    partial void Onfecha_registro_proveedorChanged();
    #endregion
		
		public proveedores()
		{
			this._productos = new EntitySet<productos>(new Action<productos>(this.attach_productos), new Action<productos>(this.detach_productos));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_proveedor", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_proveedor
		{
			get
			{
				return this._id_proveedor;
			}
			set
			{
				if ((this._id_proveedor != value))
				{
					this.Onid_proveedorChanging(value);
					this.SendPropertyChanging();
					this._id_proveedor = value;
					this.SendPropertyChanged("id_proveedor");
					this.Onid_proveedorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre_empresa", DbType="NVarChar(100)")]
		public string nombre_empresa
		{
			get
			{
				return this._nombre_empresa;
			}
			set
			{
				if ((this._nombre_empresa != value))
				{
					this.Onnombre_empresaChanging(value);
					this.SendPropertyChanging();
					this._nombre_empresa = value;
					this.SendPropertyChanged("nombre_empresa");
					this.Onnombre_empresaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_direccion", DbType="NVarChar(100)")]
		public string direccion
		{
			get
			{
				return this._direccion;
			}
			set
			{
				if ((this._direccion != value))
				{
					this.OndireccionChanging(value);
					this.SendPropertyChanging();
					this._direccion = value;
					this.SendPropertyChanged("direccion");
					this.OndireccionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefono", DbType="Int")]
		public System.Nullable<int> telefono
		{
			get
			{
				return this._telefono;
			}
			set
			{
				if ((this._telefono != value))
				{
					this.OntelefonoChanging(value);
					this.SendPropertyChanging();
					this._telefono = value;
					this.SendPropertyChanged("telefono");
					this.OntelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_registro_proveedor", DbType="NVarChar(100)")]
		public string fecha_registro_proveedor
		{
			get
			{
				return this._fecha_registro_proveedor;
			}
			set
			{
				if ((this._fecha_registro_proveedor != value))
				{
					this.Onfecha_registro_proveedorChanging(value);
					this.SendPropertyChanging();
					this._fecha_registro_proveedor = value;
					this.SendPropertyChanged("fecha_registro_proveedor");
					this.Onfecha_registro_proveedorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="proveedores_productos", Storage="_productos", ThisKey="id_proveedor", OtherKey="id_proveedor")]
		public EntitySet<productos> productos
		{
			get
			{
				return this._productos;
			}
			set
			{
				this._productos.Assign(value);
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
		
		private void attach_productos(productos entity)
		{
			this.SendPropertyChanging();
			entity.proveedores = this;
		}
		
		private void detach_productos(productos entity)
		{
			this.SendPropertyChanging();
			entity.proveedores = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.usuarios")]
	public partial class usuarios : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_usuario;
		
		private string _usuario;
		
		private string _clave;
		
		private System.Nullable<int> _tipo;
		
		private string _fecha_registro;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_usuarioChanging(int value);
    partial void Onid_usuarioChanged();
    partial void OnusuarioChanging(string value);
    partial void OnusuarioChanged();
    partial void OnclaveChanging(string value);
    partial void OnclaveChanged();
    partial void OntipoChanging(System.Nullable<int> value);
    partial void OntipoChanged();
    partial void Onfecha_registroChanging(string value);
    partial void Onfecha_registroChanged();
    #endregion
		
		public usuarios()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_usuario", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_usuario
		{
			get
			{
				return this._id_usuario;
			}
			set
			{
				if ((this._id_usuario != value))
				{
					this.Onid_usuarioChanging(value);
					this.SendPropertyChanging();
					this._id_usuario = value;
					this.SendPropertyChanged("id_usuario");
					this.Onid_usuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_usuario", DbType="NVarChar(100)")]
		public string usuario
		{
			get
			{
				return this._usuario;
			}
			set
			{
				if ((this._usuario != value))
				{
					this.OnusuarioChanging(value);
					this.SendPropertyChanging();
					this._usuario = value;
					this.SendPropertyChanged("usuario");
					this.OnusuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_clave", DbType="NVarChar(100)")]
		public string clave
		{
			get
			{
				return this._clave;
			}
			set
			{
				if ((this._clave != value))
				{
					this.OnclaveChanging(value);
					this.SendPropertyChanging();
					this._clave = value;
					this.SendPropertyChanged("clave");
					this.OnclaveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tipo", DbType="Int")]
		public System.Nullable<int> tipo
		{
			get
			{
				return this._tipo;
			}
			set
			{
				if ((this._tipo != value))
				{
					this.OntipoChanging(value);
					this.SendPropertyChanging();
					this._tipo = value;
					this.SendPropertyChanged("tipo");
					this.OntipoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_registro", DbType="NVarChar(100)")]
		public string fecha_registro
		{
			get
			{
				return this._fecha_registro;
			}
			set
			{
				if ((this._fecha_registro != value))
				{
					this.Onfecha_registroChanging(value);
					this.SendPropertyChanging();
					this._fecha_registro = value;
					this.SendPropertyChanged("fecha_registro");
					this.Onfecha_registroChanged();
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
