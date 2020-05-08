function StartIsotope() {
    $(document).ready(function () {
        var $container = $('#grid');
        $container.isotope({
            itemSelector: '.grid-item',
            layoutMode: 'fitRows',
            masonry: {
                columnWidth: 40,
                isFitWidth: true
            }
        });

        $('#nav a').click(function () {
            console.log("resize!");
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

function UpdateFlickity() {
    $('.main-carousel').flickity('destroy').flickity({
        // options
        cellAlign: 'left',
        contain: true,
        //imagesLoaded: true,
        lazyLoad: 3
    });
}

function StartFlickity() {
    $(document).ready(function () {
        //var $container = $('#grid');
        $('.main-carousel').flickity('destroy').flickity({
            // options
            cellAlign: 'left',
            contain: true,
            //imagesLoaded: true,
            lazyLoad: 3
        });

        //$('#nav a').click(function () {
        //    console.log("resize!");
        //    var selector = $(this).attr('data-filter');
        //    $container.isotope({
        //        filter: selector,
        //        animationOptions: {
        //            duration: 750,
        //            easing: 'linear',
        //            queue: false,

        //        }
        //    });
        //    return false;
        //});
    });
}