var HomeView = function () {

    var snapDrawerView;

    this.initialize = function() {
        this.$el = $('<div/>');
        snapDrawerView = new SnapDrawerView();
        this.render();
    };

    this.render = function() {
        this.$el.html(this.template());
        $('.snap-drawers', this.$el).html(snapDrawerView.$el);
        return this;
    };

    this.initialize();
}