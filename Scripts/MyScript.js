$(document).ready(function () {
    GetShowData();
});

function GetShowData() {
    $.getJSON('api/Countries')
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<option>', { text: item }).appendTo($('#country'))
            })
        })
        .fail(function (data) {
            console.log("Error getting Countries");
        });
}

function getGDP() {
    $("#gdpList").empty();
    $.getJSON('api/GDP')
        .done(function (data) {
            //console.log(data);
            $.each(data, function (key, item) {
                //console.log(item);
                $('<li>', {
                    text: item.Country + " || GDP: " + item.GDP + " || League Percentage: " + item.LeaguePopularity 
                        + " || Genshin Percentage: " + item.GenshinPopularity}).appendTo($('#gdpList'))
            })
        })
        .fail(function (data) {
            console.log("Error getting GDP list");
        });
}

function getCountry() {
    $("#countryList").empty();
    var country = $("#country").children("option:selected").val();
    //console.log(country);
    $.getJSON('api/Countries' + '/' + country)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<p>', { text: country + " || League Percentage: " + item.LeaguePopularity + " || Genshin Percentage: " + item.GenshinPopularity })
                    .appendTo($('#countryList'))
            })
        })
        .fail(function (data) {
            console.log("Error getting " + country + " data");
        });
}
1
function getLadderScore() {
    $("#ladderList").empty();
    var ladder = $("#ladderScore").children("option:selected").val();
    //console.log(store);
    $.getJSON('api/LadderScore' + '/' + ladder)
        .done(function (data) {
            //console.log(data);
            $.each(data, function (key, item) {
                //console.log(item);
                $('<li>', {
                    text: item.Country + " || LadderScore: " + item.LadderScore + " || League Percentage: " + item.LeaguePopularity
                        + " || Genshin Percentage: " + item.GenshinPopularity}).appendTo($('#ladderList'))
            })
        })
        .fail(function (data) {
            console.log("Error getting ladder list");
        });
}