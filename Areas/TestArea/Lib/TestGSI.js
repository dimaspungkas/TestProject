$(document).ready(function () {

    //#region SOAL 1

    $("#soal1").on("click", "#btnProcess", function () {
        try {
            var sampleInput = $("#soal1 #sampleInput").val();
            $.ajax({
                type: "POST",
                url: "TestGSI/GetResultSoal1",
                dataType: "json",
                data: { sampleInput: sampleInput },
                success: function (result) {
                    if (result.success) {
                        $("#soal1 #sampleOutput").val(result.data);
                    } else {
                        console.log("Error: " + result.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.log("AJAX error:", status, error);
                    console.log("Full response:", xhr.responseText);
                }
            }).done(function () {
                getResult2();
            });
        } catch (err) {
            console.log("Err: " + err.message);
        }
    });

    //#endregion

    //#region SOAL 2

    function getResult2() {
        try {
            var sampleInput = $("#soal1 #sampleOutput").val();
            $.ajax({
                type: "POST",
                url: "TestGSI/GetResultSoal2",
                dataType: "json",
                data: { sampleInput: sampleInput },
                success: function (result) {
                    if (result.success) {
                        $("#soal2 #sampleInput").val(result.input);
                        $("#soal2 #sampleOutput").val(result.data);
                        $("#soal3 #sampleInput").val(result.data);
                    } else {
                        console.log("Error: " + result.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.log("AJAX error:", status, error);
                    console.log("Full response:", xhr.responseText);
                }
            }).done(function () {
                getResult3();
            });
        } catch (err) {
            console.log("Err: " + err.message);
        }
    };

    //#endregion

    //#region SOAL 3

    function getResult3() {
        try {
            var sampleInput = $("#soal3 #sampleInput").val();
            $.ajax({
                type: "POST",
                url: "TestGSI/GetResultSoal3",
                dataType: "json",
                data: { sampleInput: sampleInput },
                success: function (result) {
                    if (result.success) {
                        $("#soal3 #explanation").val(result.explanation);
                        $("#soal3 #sampleOutput").val(result.data);
                        $("#soal4 #sampleInput").val(result.data);
                    } else {
                        console.log("Error: " + result.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.log("AJAX error:", status, error);
                    console.log("Full response:", xhr.responseText);
                }
            }).done(function () {
                getResult4();
            });
        } catch (err) {
            console.log("Err: " + err.message);
        }
    };

    //#endregion

    //#region SOAL 4

    function getResult4() {
        try {
            var sampleInput = $("#soal4 #sampleInput").val();
            $.ajax({
                type: "POST",
                url: "TestGSI/GetResultSoal4",
                dataType: "json",
                data: { sampleInput: sampleInput },
                success: function (result) {
                    if (result.success) {
                        $("#soal4 #explanation").val(result.explanation);
                        $("#soal4 #sampleOutput").val(result.data);
                        $("#soal5 #sampleInput").val(result.data);
                    } else {
                        console.log("Error: " + result.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.log("AJAX error:", status, error);
                    console.log("Full response:", xhr.responseText);
                }
            }).done(function () {
                getResult5();
            });
        } catch (err) {
            console.log("Err: " + err.message);
        }
    };

    //#endregion

    //#region SOAL 5

    function getResult5() {
        try {
            var sampleInput = $("#soal5 #sampleInput").val();
            $.ajax({
                type: "POST",
                url: "TestGSI/GetResultSoal5",
                dataType: "json",
                data: { sampleInput: sampleInput },
                success: function (result) {
                    if (result.success) {
                        $("#soal5 #explanation").val(result.explanation);
                        $("#soal5 #sampleOutput").val(result.data);
                    } else {
                        console.log("Error: " + result.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.log("AJAX error:", status, error);
                    console.log("Full response:", xhr.responseText);
                }
            });
        } catch (err) {
            console.log("Err: " + err.message);
        }
    };

    //#endregion

});