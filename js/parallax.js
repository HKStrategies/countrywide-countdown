$(document).ready(function(){
// Enable parallax on desktop
    if (Modernizr.mq('only screen and (min-width: 650px)')) {
        $('.hero').parallax({imageSrc: '/images/agent-lineup-v1-small.jpg'});
    }
});
