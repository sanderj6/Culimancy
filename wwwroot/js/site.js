function StartIsotope() {
    $(document).ready(function () {
        var $container = $('#grid');
        $container.isotope({
            itemSelector: '.grid-item',
            layoutMode: 'fitRows'
        });

        $('#nav a').click(function () {
            var selector = $(this).attr('data-filter');
            $container.isotope({
                filter: selector,
                animationOptions: {
                    duration: 750,
                    easing: 'linear',
                    queue: false,

                }
            });
            return false;
        });
    });
}