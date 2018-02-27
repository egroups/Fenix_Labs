# Written By Ismael Heredia in the year 2017

import base64,hashlib,os,sys
from time import gmtime, strftime

class Function(object):

    def mensaje(self,titulo,contenido,tipo):
	    return "<script>"+ \
		"swal({"+ \
				"title: '"+titulo+"',"+ \
				"text: '"+contenido+"',"+ \
				"type:'"+tipo+"',"+ \
				"html:true,"+ \
				"animation: false"+ \
	     "});"+ \
		"</script>"

    def mensaje_con_redireccion(self,titulo,contenido,tipo,ruta):
	    return "<script>"+ \
		"swal({"+ \
				"title: '"+titulo+"',"+ \
				"text: '"+contenido+"',"+ \
				"type:'"+tipo+"',"+ \
				"html:true,"+ \
				"animation: false"+ \
	     "},function() {"+ \
	        "window.location.href = '"+ruta+"';"+ \
	     "});"+ \
		"</script>"

    def getFecha(self):
	    return strftime("%m/%d/%Y", gmtime())

    def valid_digit(self,text):
	    return text.isdigit()

    def md5_encode(self,text):
	    encode = hashlib.md5()
	    encode.update(text.encode("utf-8"))
	    return encode.hexdigest()

    def base64_encode(self,text):
        encoded = base64.b64encode(text.encode())
        return encoded.decode('utf-8')

    def base64_decode(self,text):
        decoded = base64.b64decode(text.encode())
        return decoded.decode('utf-8')

    def destroy(self):
        pass