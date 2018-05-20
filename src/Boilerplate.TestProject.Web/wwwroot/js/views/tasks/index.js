(function ($) {
    $(function () {

        var _$taskStateCombobox = $('#TaskStateCombobox');
        var _$addNewTask = $('#AddNewTaskBtn');

        _$taskStateCombobox.change(function() {
            location.href = '/Tasks?state=' + _$taskStateCombobox.val();
        });

        _$addNewTask.click(function () {
            location.href = '/Tasks/Create';
        });
    });
})(jQuery);