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