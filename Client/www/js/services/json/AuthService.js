var AuthService = function () {
	
	var url;

    this.initialize = function(serviceURL) {
    	url = serviceURL ? serviceURL : 'api/authenticate.json';
        var deferred = $.Deferred();
        deferred.resolve();
        return deferred.promise();
    };
    
    this.authenticate = function (email, password) {
    	console.log(url);
    	return $.ajax({
			url: url, //url: url + '/auth/login',
			headers: { 'Access-Control-Allow-Origin': '*' },
			type:'GET',
			dataType: 'json',
			async: false,
			// data: "email="+ email + "&password=" + password,
		    // beforeSend: function (xhr){ 
		        // xhr.setRequestHeader('Authorization', "Basic " + btoa(email + ":" + password)); 
		    // },
		    error: function(xhr){
				if (xhr.status == '401') {
					alert('Invalid email or password');
				} else if (xhr.status == '500') {
					alert('An error occurred, please try again later.');
				}
			}
		});
    };
    
};