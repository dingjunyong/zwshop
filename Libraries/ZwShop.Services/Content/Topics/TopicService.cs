

using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Caching;
using ZwShop.Services.Data;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Content.Topics
{
    public partial class TopicService : ITopicService
    {
        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly ShopObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public TopicService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="topicId">Topic identifier</param>
        public void DeleteTopic(int topicId)
        {
            //var topic = GetTopicById(topicId);
            //if (topic == null)
            //    return;

            
            //if (!_context.IsAttached(topic))
            //    _context.Topics.Attach(topic);
            //_context.DeleteObject(topic);
            //_context.SaveChanges();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public void InsertTopic(Topic topic)
        {
            //if (topic == null)
            //    throw new ArgumentNullException("topic");

            //topic.Name = CommonHelper.EnsureNotNull(topic.Name);
            //topic.Name = CommonHelper.EnsureMaximumLength(topic.Name, 200);
            //topic.Password = CommonHelper.EnsureNotNull(topic.Password);
            //topic.Password = CommonHelper.EnsureMaximumLength(topic.Password, 200);

            
            
            //_context.Topics.AddObject(topic);
            //_context.SaveChanges();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public void UpdateTopic(Topic topic)
        {
            //if (topic == null)
            //    throw new ArgumentNullException("topic");

            //topic.Name = CommonHelper.EnsureNotNull(topic.Name);
            //topic.Name = CommonHelper.EnsureMaximumLength(topic.Name, 200);
            //topic.Password = CommonHelper.EnsureNotNull(topic.Password);
            //topic.Password = CommonHelper.EnsureMaximumLength(topic.Password, 200);

            
            //if (!_context.IsAttached(topic))
            //    _context.Topics.Attach(topic);

            //_context.SaveChanges();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a topic by template identifier
        /// </summary>
        /// <param name="topicId">topic identifier</param>
        /// <returns>topic</returns>
        public Topic GetTopicById(int topicId)
        {
            //if (topicId == 0)
            //    return null;

            
            //var query = from t in _context.Topics
            //            where t.TopicId == topicId
            //            select t;
            //var topic = query.SingleOrDefault();

            //return topic;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <returns>topic collection</returns>
        public List<Topic> GetAllTopics()
        {
            
            //var query = from t in _context.Topics
            //            orderby t.Name
            //            select t;
            //var topics = query.ToList();
            //return topics;
            throw new NotImplementedException();
        }


        #endregion
    }
}