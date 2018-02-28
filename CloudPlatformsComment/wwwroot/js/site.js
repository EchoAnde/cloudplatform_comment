// Write your JavaScript code.
$(function () {
    onLoaded();
});

function onLoaded() {
    $(".star").raty({
        path: "/images",
        readOnly: true,
        score: function () {
            return $(this).attr('data-score');
        },
        hints: ["好差啊！", "差评！", "可以用!-_-", "还不错^_^", "太优秀了"]
    });
}