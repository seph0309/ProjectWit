// global scope
var app = {
	
	initialize: function() {
		this.email = window.localStorage.getItem("email");
		this.password = window.localStorage.getItem("password");
		this.role = window.localStorage.getItem("role");
	},
	
	login: function(email, password, role) {
		this.email = email;
		this.password = password;
		this.role = role;
		
		window.localStorage.setItem("email", email);
		window.localStorage.setItem("password", password);
		window.localStorage.setItem("role", role);
	},
	
	signout: function() {
		if (confirm("Exit application?")) {
			window.localStorage.setItem("email", null);
			window.localStorage.setItem("password", null);
			window.localStorage.setItem("role", null);
			
			window.location = 'index.html';
		}
	}
	
};

// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function () {

    /* ---------------------------------- Local Variables ---------------------------------- */
    LoginView.prototype.template = Handlebars.compile($("#login-tpl").html());
    SnapDrawerView.prototype.template = Handlebars.compile($("#snap-drawer-tpl").html());
    HomeView.prototype.template = Handlebars.compile($("#home-tpl").html());
	TableSelectView.prototype.template = Handlebars.compile($("#table-select-tpl").html());
	
	var authService = new AuthService();
	var homeService = new HomeService();
	var tableSelectService = new TableSelectService();
	
    var slider = new PageSlider($('body'));
    
    authService.initialize().done(function () {
    	
    	router.addRoute('', function() {
            console.log('login');
            slider.slidePage(new LoginView(authService).render().$el);
        });
        
        router.addRoute('table-select', function() {
	        console.log('table-select');
	        tableSelectService.initialize().done(function () {
		        slider.slidePage(new TableSelectView(tableSelectService).render().$el);
	        });
	    });
	    
	    router.addRoute('home', function() {
	        console.log('home');
	        homeService.initialize().done(function () {
		        slider.slidePage(new HomeView(homeService).render().$el);
	        });
	    });
	
	    router.start();
    	
    });
    
    //service.initialize().done(function () {
    //});

    /* --------------------------------- Event Registration -------------------------------- */
    document.addEventListener('deviceready', function () {
        StatusBar.overlaysWebView( false );
        StatusBar.backgroundColorByHexString('#ffffff');
        StatusBar.styleDefault();
        FastClick.attach(document.body);
        if (navigator.notification) { // Override default HTML alert with native dialog
            window.alert = function (message) {
                navigator.notification.alert(
                    message,    // message
                    null,       // callback
                    "WitMobile", // title
                    'OK'        // buttonName
                );
            };
        }
    }, false);

    /* ---------------------------------- Local Functions ---------------------------------- */

   $('.submit').click(function (e) {
	    e.preventDefault();
	});

}());

/* Prevent Safari opening links when viewing as a Mobile App */
/*
(function (a, b, c) {
    if (c in b && b[c]) {
        var d, e = a.location,
                f = /^(a|html)$/i;
        a.addEventListener("click", function (a) {
            d = a.target;
            while (!f.test(d.nodeName))
                d = d.parentNode;
            "href" in d && (d.href.indexOf("http") || ~d.href.indexOf(e.host)) && (a.preventDefault(), e.href = d.href);
        }, !1);
    }
})(document, window.navigator, "standalone");
*/

/*
var snapper = new Snap({
    element: document.getElementById('content')
});

//* Get reference to toggle button, the html element with ID "open-left" 
var myToggleButton = document.getElementById('open-left');

//* Add event listener to our toggle button 
myToggleButton.addEventListener('click', function () {

    if (snapper.state().state == "left") {
        snapper.close();
    } else {
        snapper.open('left');
    }

});
*/
