var TableSelectView = function (service) {

    var snapDrawerView;
    var tables;

    this.initialize = function() {
        this.$el = $('<div/>');
        snapDrawerView = new SnapDrawerView();
        this.fetchTables();
    };

    this.render = function() {
        this.$el.html(this.template(tables));
        $('.snap-drawers', this.$el).html(snapDrawerView.render().$el);
        return this;
    };
    
    this.fetchTables = function() {
    	var self = this;
    	service.fetchTables(1).done(function(result) {
    		console.log(result);
            if ("OK" == result.status) {
            	self.setTables(result.data);
            } else {
            	alert (result.message);
            }
        });
    };
    
    this.setTables = function(list) {
    	tables = list;
    	this.render();
    };

    this.initialize();
};