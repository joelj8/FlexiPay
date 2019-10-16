
    $(document).ready(function() {
        //alert("Hey! I am ready");
        $('.jsbasicdropdown').select2();

        $(".numberformat").inputmask({ alias: "currency", prefix: '' });

        $(".datepicker").datepicker({
            dateFormat: "dd/mm/yy",
            showStatus: true,
            showWeeks: true,
            currentText: 'Now',
            autoSize: true,
            gotoCurrent: true,
            showAnim: 'clip',
            highlightWeek: true
        });
        //$(".datepicker").datepicker("option", "dateFormat", "dd/mm/yy");
        //$(".datepicker").datepicker("option", "showAnim", "clip");

    });
