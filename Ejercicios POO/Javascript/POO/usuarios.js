// Written By Ismael Heredia in the year 2016

function Usuario(id_usuario,nombre,password,tipo,fecha_registro){
	this.id_usuario = id_usuario;
	this.nombre = nombre;
	this.password = password;
	this.tipo = tipo;
	this.fecha_registro = fecha_registro;
}

Usuario.prototype.getId_usuario=function(){
	return this.id_usuario;
};
Usuario.prototype.setId_usuario=function(id_usuario){
	this.id_usuario = id_usuario;
};

Usuario.prototype.getNombre=function(){
	return this.nombre;
};
Usuario.prototype.setNombre=function(nombre){
	this.nombre = nombre;
};

Usuario.prototype.getPassword=function(){
	return this.password;
};
Usuario.prototype.setPassword=function(password){
	this.password = password;
};

Usuario.prototype.getTipo=function(){
	return this.tipo;
};
Usuario.prototype.setTipo=function(tipo){
	this.tipo = tipo;
};

Usuario.prototype.getFecha_registro=function(){
	return this.fecha_registro;
};
Usuario.prototype.setFecha_registro=function(fecha_registro){
	this.fecha_registro = fecha_registro;
};

Usuario.prototype.toString=function(){
	return "[+] ID Usuario : "+this.id_usuario+"\n"+"[+] Nombre : "+this.nombre+"\n"+"[+] Password : "+this.password
			+"\n"+"[+] Tipo : "+this.tipo+"\n"+"[+] Fecha registro : "+this.fecha_registro;
};