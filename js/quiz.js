$(function () {

    var fadeDuration = 700;
    var currentQuestion = 1;
    var answersArr = {};
    var totalQuestions = $('.quiz__options').length;
    _init();


    function _init() {

        $('.quiz__options').hide().eq(0).show();
        $('.quiz-lead').hide().eq(0).show();

        if (Modernizr.touch) {
            $(document).on('touchend', '.quiz__options li', function () {
                var answer = $(this).closest('.quiz__options').find('li').index($(this));
                _next(answer);
            });
        } else {
            $(document).on('click', '.quiz__options li', function () {
                var answer = $(this).closest('.quiz__options').find('li').index($(this));
                _next(answer);
            });
        }
    }


    function _next(answer) {
        answersArr['q_' + currentQuestion] = answer;

        currentQuestion++;

        if (currentQuestion - 1 >= totalQuestions) {
            _finished();
            return true;
        }

        $('.quiz__options').hide().eq(currentQuestion - 1).fadeIn(fadeDuration);
        $('.quiz-lead').hide().eq(currentQuestion - 1).fadeIn(fadeDuration);
        $('.prism_top , .prism_right').html(currentQuestion);
    }

    function _finished() {

        var responseJSON = JSON.stringify(answersArr);
        var escapedResponses = escapeHtml(responseJSON);
        var $form = $('<form action="results.php" method="POST"></form>').appendTo('body');
        $form
        .append('<input type="submit">')
        .append('<input name="responses" value="' + escapedResponses + '">')
        .trigger('submit');
    }


    function escapeHtml(string) {
        var entityMap = {
            "&": "&amp;",
            "<": "&lt;",
            ">": "&gt;",
            '"': '&quot;',
            "'": '&#39;',
            "/": '&#x2F;'
        };
        return String(string).replace(/[&<>"'\/]/g, function (s) {
            return entityMap[s];
        });
    }

});
