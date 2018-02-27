
app.factory('sessionService', ['$http', function($http){
	return{
		set:function(key,value){
			return sessionStorage.setItem(key,value);
		},
		get:function(key){
			return sessionStorage.getItem(key);
		},
		getUsername:function(key){
			var content = sessionStorage.getItem(key);
			var values = content.split(':');
			return values[1];

		},
		destroy:function(key){
			$http.post('includes/destroy_session.php');
			return sessionStorage.removeItem(key);
		}
	};
}])