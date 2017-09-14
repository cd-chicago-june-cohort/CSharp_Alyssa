// Write your Javascript code.
$(document).ready(function(){
    $('form').on('submit', function(event){
        event.preventDefault();
        var title = $('input[name=title]').val();
        $('input[name=title]').val('');
        // ADD API KEY BEFORE RUNNING
        var url = "https://api.themoviedb.org/3/search/movie?api_key=***ADDAPIKEY****&language=en-US&query=" + title;
        $.get(url, function(response){
            var movie = response["results"][0];
            var data = {
                title: movie["title"],
                rating: movie["vote_average"],
                release: movie["release_date"]
            };
            $.post("movie", data, function(){
                var html = '<p>'+ movie["title"] + ' &emsp; Rating: ' + movie["vote_average"] + ' &emsp; Released ' + movie["release_date"] + '</p>'
                $('#movies').prepend(html);
            });
        });
    });

});