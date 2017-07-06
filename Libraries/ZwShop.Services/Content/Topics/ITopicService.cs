using System.Collections.Generic;

namespace ZwShop.Services.Content.Topics
{
    public partial interface ITopicService
    {
        void DeleteTopic(int topicId);

        void InsertTopic(Topic topic);

        void UpdateTopic(Topic topic);

        Topic GetTopicById(int topicId);

        List<Topic> GetAllTopics();
    }
}