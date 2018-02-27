// Written By Ismael Heredia in the year 2016

function Producto(id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro){
	this.id_producto = id_producto;
	this.nombre_producto = nombre_producto;
	this.descripcion = descripcion;
	this.precio = precio;
	this.id_proveedor = id_proveedor;
	this.fecha_registro = fecha_registro;
}

Producto.prototype.getId_producto=function(){
	return this.id_producto;
};
Producto.prototype.setId_producto=function(id_producto){
	this.id_producto = id_producto;
};

Producto.prototype.getNombre_producto=function(){
	return this.nombre_producto;
};
Producto.prototype.setNombre_producto=function(nombre_producto){
	this.nombre_producto = nombre_producto;
};

Producto.prototype.getDescripcion=function(){
	return this.descripcion;
};
Producto.prototype.setDescripcion=function(descripcion){
	this.descripcion = descripcion;
};

Producto.prototype.getPrecio=function(){
	return this.precio;
};
Producto.prototype.setPrecio=function(precio){
	this.precio = precio;
};

Producto.prototype.getId_proveedor=function(){
	return this.id_proveedor;
};
Producto.prototype.setId_proveedor=function(id_proveedor){
	this.id_proveedor = id_proveedor;
};

Producto.prototype.getFecha_registro=function(){
	return this.fecha_registro;
};
Producto.prototype.setFecha_registro=function(fecha_registro){
	this.fecha_registro = fecha_registro;
};

Producto.prototype.toString=function(){
	return "[+] ID Producto : "+this.id_producto+"\n"+"[+] Nombre producto : "+this.nombre_producto+"\n"+
			"[+] Descripcion : "+this.descripcion+"\n"+"[+] Precio : "+this.precio+"\n"+
			"[+] Id Proveedor : "+this.id_proveedor+"\n"+"[+] Fecha Registro : "+this.fecha_registro;
};