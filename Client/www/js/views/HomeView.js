var HomeView = function (service, tableId, tableName) {

    var snapDrawerView;
    var highlights;

    this.initialize = function() {
        this.$el = $('<div/>');
        snapDrawerView = new SnapDrawerView();
        this.fetchHighlights();
    };

    this.render = function() {
        this.$el.html(this.template(highlights));
        $('.snap-drawers', this.$el).html(snapDrawerView.render().$el);
        return this;
    };
    
    this.fetchHighlights = function() {
    	var self = this;
    	service.fetchHighlights().done(function(result) {
    		console.log(result);
            if ("OK" == result.status) {
            	self.setHighlights(result.data);
            } else {
            	alert (result.message);
            }
        });
    };
    
    this.setHighlights = function(list) {
    	highlights = list;
    	this.render();
    };

    this.initialize();
};