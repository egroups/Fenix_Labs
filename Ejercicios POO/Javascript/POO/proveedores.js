// Written By Ismael Heredia in the year 2016

function Proveedor(id_proveedor,nombre_empresa,direccion,telefono,fecha_registro){
	this.id_proveedor=id_proveedor;
	this.nombre_empresa=nombre_empresa;
	this.direccion = direccion;
	this.telefono = telefono;
	this.fecha_registro = fecha_registro;
}

Proveedor.prototype.getId_proveedor=function(){
	return this.id_proveedor;
};
Proveedor.prototype.setId_proveedor=function(id_proveedor){
	this.id_proveedor = id_proveedor;
};

Proveedor.prototype.getNombre_empresa=function(){
	return this.nombre_empresa;
};
Proveedor.prototype.setNombre_empresa=function(nombre_empresa){
	this.nombre_empresa = nombre_empresa;
};

Proveedor.prototype.getDireccion=function(){
	return this.direccion;
};
Proveedor.prototype.setDireccion=function(direccion){
	this.direccion = direccion;
};

Proveedor.prototype.getTelefono=function(){
	return this.telefono;
};
Proveedor.prototype.setTelefono=function(telefono){
	this.telefono = telefono;
};

Proveedor.prototype.getFecha_registro=function(){
	return this.fecha_registro;
};
Proveedor.prototype.setFecha_registro=function(fecha_registro){
	this.fecha_registro = fecha_registro;
};

Proveedor.prototype.toString=function(){
	return "[+] ID Proveedor : "+this.id_proveedor + "\n" + "[+] Nombre empresa : "+this.nombre_empresa
			+ "\n" + "[+] Direccion : "+this.direccion + "\n" + "[+] Telefono : "+this.telefono
			+ "\n" + "[+] Fecha registro : "+this.fecha_registro;
};