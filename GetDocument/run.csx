#r "Microsoft.Azure.Documents.Client"
using System.Net;
using System.Net.Http.Headers;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, DocumentClient client, TraceWriter log)
{
    string qid = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "qid", true) == 0)
        .Value;

    var query = client.CreateDocumentQuery<Item>(
        UriFactory.CreateDocumentCollectionUri("questionDatabase", "Questions"),
        new FeedOptions { EnableCrossPartitionQuery = true })
        .Where(d => d.qid == Convert.ToInt32(qid))
        .AsDocumentQuery();

    var results = await query.ExecuteNextAsync();
    var hasDocument = results.Any();

    return req.CreateResponse(hasDocument ? HttpStatusCode.OK: HttpStatusCode.NotFound);
}

public class Item
{
    public int qid { get; set; }
}
