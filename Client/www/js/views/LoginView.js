var LoginView = function (service) {

    this.initialize = function() {
        this.$el = $('<div/>');
        this.$el.on('click', '.submit', this.authenticate);
        this.render();
    };

    this.render = function() {
        this.$el.html(this.template());
        $('.content', this.$el).html();
        return this;
    };

    this.authenticate = function() {
    	
    	if (!$('.email').val() || !$('.password').val()) {
    		alert('Please check your inputs.');
    		return;
    	}
    	
    	var email = $('.email').val();
    	var password = $('.password').val();
    	
    	console.log(email + ' ' + password);
        service.authenticate(email, password).done(function(result) {
        	console.log(result);
            if ("OK" == result.status) {
            	console.log("auth success");
            	//app.login(email, password, result.data.role);
	            window.location = "#table-select";
            } else {
            	alert (result.message);
            }
        });
    };

    this.initialize();
};