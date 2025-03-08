$(document).ready(function () {

    //#region LOGIKA 1

    var arrayVal = [2, 7, 11, 15];

    function getLogika1() {
        var inputVal = $("#Logika1 #sampleInput").val() == "" ? "" : $("#Logika1 #sampleInput").val();
        var inputArray = $("#Logika1 #ArrayVal").val() == "" ? arrayVal : $("#Logika1 #ArrayVal").val();
        $.ajax({
            url: "Logika1/GetLogika1",
            type: "POST",
            dataType: "json",
            data: { 'inputVal': inputVal, 'inputArray': inputArray },
            success: function (result) {
                if (result.success) {
                    $("#Logika1 #sampleOutput").val(result.message);
                } else {
                    $("#Logika1 #sampleOutput").val("<no way>");
                }
            },
        });
    }

    $("#Logika1 #sampleInput").on("keyup", function () {
        try {
            $("#Logika1 #sampleOutput").val("");
            var inputVal = $("#Logika1 #sampleInput").val() == "" ? "" : $("#Logika1 #sampleInput").val();
            var inputArray = $("#Logika1 #ArrayVal").val() == "" ? arrayVal : $("#Logika1 #ArrayVal").val();
            var result = 0;
            var resultVal = false;
            if (inputVal != "") getLogika1();
        } catch (err) {
            alert("Err: " + err.message);
        }
    });

    //#endregion

    //#region LOGIKA 2, collaborate with chatgpt

    var dictionary = ["hot", "dot", "dog", "lot", "log"];

    function isOneLetterDiff(word1, word2) {
        if (word1.length !== word2.length) return false;
        let diffCount = 0;
        for (let i = 0; i < word1.length; i++) {
            if (word1[i] !== word2[i]) diffCount++;
            if (diffCount > 1) return false;
        }
        return diffCount === 1;
    }

    function findShortestTransformation(startWord, endWord) {
        dictionary = ["hot", "dot", "dog", "lot", "log"];
        if (!dictionary.includes(startWord)) dictionary.push(startWord);
        if (!dictionary.includes(endWord)) dictionary.push(endWord);

        let queue = [[startWord]];
        let visited = new Set();
        visited.add(startWord);

        while (queue.length > 0) {
            let path = queue.shift();
            let lastWord = path[path.length - 1];

            if (lastWord === endWord) return path.join(" ");

            for (let word of dictionary) {
                if (!visited.has(word) && isOneLetterDiff(lastWord, word)) {
                    visited.add(word);
                    queue.push([...path, word]);
                }
            }
        }
        return false;
    }

    $("#Logika2 #btnTry").on("click", function () {
        try {
            $("#Logika2 #sampleOutput").val("");
            var inputVal = $("#Logika2 #sampleInput").val();
            if (inputVal != "") {
                var resArray = inputVal.split(' ');

                let result = findShortestTransformation(resArray[0], resArray[1]);
                $("#Logika2 #sampleOutput").val(result ? result : "<no way>");
            }
        } catch (err) {
            alert("Err: " + err.message);
        }
    });

    //#endregion

    //#region LOGIKA 5

    $("#Logika5 #btnTry").on("click", function () {
        try {
            $("#Logika5 #sampleOutput").val("");
            var inputVal = $("#Logika5 #sampleInput").val();
            inputVal = inputVal.split(",");
            var minPrice = inputVal[0];
            var maxProfit = 0;
            var result = "";
            if (inputVal != "") {
                for (var i = 1; i < inputVal.length; i++) {
                    var profit = inputVal[i] - minPrice;
                    maxProfit = Math.max(maxProfit, profit);
                    minPrice = Math.min(minPrice, inputVal[i]);
                }
                result = maxProfit > 0 ? maxProfit : "Harga selalu turun";
                $("#Logika5 #sampleOutput").val(result);
            }
        } catch (err) {
            alert("Err: " + err.message);
        }
    });

    //#endregion

});