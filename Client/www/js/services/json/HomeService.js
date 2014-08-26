var HomeService = function () {
	
	var url;

    this.initialize = function(serviceURL) {
    	url = serviceURL ? serviceURL :  'api/highlights.json';
        var deferred = $.Deferred();
        deferred.resolve();
        return deferred.promise();
    };
    
    this.fetchHighlights = function() {
    	
    	// spinnerplugin.show();
    	return $.ajax({
			url: url,
			headers: { 'Access-Control-Allow-Origin': '*' },
			type:'GET',
			dataType: 'json',
			async: false,
			// data: "email="+ app.email + "&password=" + app.password,
		    // beforeSend: function (xhr){ 
		        // xhr.setRequestHeader('Authorization', "Basic " + btoa(app.email + ":" + app.password)); 
		    // },
		    error: function(xhr){
		    	// spinnerplugin.hide();
		    	
				if (xhr.status == '401') {
					alert('An error occurred, please try again later.');
				} else if (xhr.status == '500') {
					alert('An error occurred, please try again later.');
				}
			}
		});
    };

    
};