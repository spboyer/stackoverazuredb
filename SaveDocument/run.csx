using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, out object questionDocument, TraceWriter log)
{

    dynamic data = req.Content.ReadAsAsync<object>().Result;
    
    questionDocument = new {
        answerCount = data.AnswerCount,
        displayName = data.Owner.DisplayName,
        profileImage = data.Owner.ProfileImage,
        profileLink = data.Owner.Link,
        tags = data.Tags,
        views = data.ViewCount,
        link = data.Link,
        createDate = data.CreationData,
        title = data.Title,
        up = data.UpVoteCount,
        down = data.DownVoteCount,
        fav = data.FavoriteCount,
        qid = data.QuestionId 
    };

    if (questionDocument != null) {
        return req.CreateResponse(HttpStatusCode.OK);
    }
    else {
        return req.CreateResponse(HttpStatusCode.BadRequest);
    }
}


/*
AnswerCount: 0
Owner.DisplayName : chinna
Owner.ProfileImage : "https://www.gravatar.com/avatar/86bbd3747a46eb63a8ee61b742f0c081?s=128&d=identicon&r=PG&f=1"
Owner.Link : "https://stackoverflow.com/users/6627954/chinna"
Tags [] : c#, asp.net, azure, angular2-forms, azure-data-lake
ViewCount : 9
Link : "https://stackoverflow.com/questions/45867088/how-to-upload-video-file-through-formdata-to-azure-datalake"
IsAnswered : false
CreationDate: {8/24/17 4:50:45 PM}
Title : "How to upload video file through FormData to Azure Datalake?"
UpVoteCount : 0
DownVoteCount: 0
FavoriteCount: 0
*/