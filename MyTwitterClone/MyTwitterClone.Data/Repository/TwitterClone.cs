using MyTwitterClone.Data.Interfaces;
using MyTwitterClone.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitterClone.Data.Repository
{
    public class TwitterClone: ITwitterClone
    {
        public string AddUser(PersonEntity personDetails)
        {
            try
            {
                var person = new PERSON()
                {
                    user_id= personDetails.user_id,
                    password=personDetails.password,
                    fullName = personDetails.fullName,
                    email = personDetails.email,
                    joined = personDetails.joined,
                    active = personDetails.active
                };
                using (var Connection = new  TwitterApplicationEntities())
                {
                    Connection.People.Add(person);
                    Connection.SaveChanges();
                }
                return "Person Added Successfully";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }
        public List<PersonEntity> GetUserDetails()
        {
            try
            {
                List<PersonEntity> poDetails;
                using (var Connection = new TwitterApplicationEntities())
                {
                    poDetails = (from p in Connection.People
                                     select new PersonEntity
                                     {
                                         user_id = p.user_id,
                                         password = p.password,
                                         fullName = p.fullName,
                                         email = p.email,
                                         joined = p.joined,
                                         active = p.active
                                     }).ToList();
                }
                return poDetails;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }
        public string UpdateUser(PersonEntity personDetails)
        {
            try
            {
                var person = new PERSON()
                {
                    user_id = personDetails.user_id,
                    password = personDetails.password,
                    fullName = personDetails.fullName,
                    email = personDetails.email,
                    joined = personDetails.joined,
                    active = personDetails.active
                };
                using (var Connection = new TwitterApplicationEntities())
                {
                    Connection.SaveChanges();
                }
                return "Updated Successfully";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }

        public List<FollowingEntity> GetFollowerDetails(FollowingEntity followerDetails)
        {
            try
            {
                List<FollowingEntity> poDetails;
                using (var Connection = new TwitterApplicationEntities())
                {
                    poDetails = (from p in Connection.FOLLOWINGs
                                 where p.following_id == followerDetails.user_id
                                 select new FollowingEntity
                                 {
                                     user_id = p.user_id,
                                     following_id=p.following_id
                                 }).ToList();
                }
                return poDetails;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }
        public List<TweetEntity> GetFollowerTweetDtls(PersonEntity personDetails)
        {
            try
            {
                List<TweetEntity> poDetails;
                using (var Connection = new TwitterApplicationEntities())
                {
                    poDetails = (from t in Connection.TWEETs
                                 join p in Connection.FOLLOWINGs on t.user_id equals p.user_id
                                 where p.following_id == personDetails.user_id
                                 select new TweetEntity
                                 {
                                     tweet_id = t.tweet_id,
                                     user_id = t.user_id,
                                     message = t.message,
                                     created = t.created
                                 }).ToList();
                }
                return poDetails;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }
        public List<TweetEntity> GetFollowingTweetDtls(PersonEntity personDetails)
        {
            try
            {
                List<TweetEntity> poDetails;
                using (var Connection = new TwitterApplicationEntities())
                {
                    poDetails = (from t in Connection.TWEETs
                                 join p in Connection.FOLLOWINGs on t.user_id equals p.following_id
                                 where p.user_id == personDetails.user_id
                                 select new TweetEntity
                                 {
                                     tweet_id = t.tweet_id,
                                     user_id = t.user_id,
                                     message = t.message,
                                     created = t.created
                                 }).ToList();
                }
                return poDetails;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }
        public List<FollowingEntity> GetFollowingDetails(FollowingEntity followerDetails)
        {
            try
            {
                List<FollowingEntity> poDetails;
                using (var Connection = new TwitterApplicationEntities())
                {
                    poDetails = (from p in Connection.FOLLOWINGs
                                 where p.user_id == followerDetails.user_id
                                 select new FollowingEntity
                                 {
                                     user_id = p.user_id,
                                     following_id = p.following_id
                                 }).ToList();
                }
                return poDetails;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }

        public string AddFollower(FollowingEntity followerDetails)
        {
            try
            {
                var person = new FOLLOWING()
                {
                    user_id = followerDetails.user_id,
                    following_id = followerDetails.following_id
                };
                using (var Connection = new TwitterApplicationEntities())
                {
                    Connection.FOLLOWINGs.Add(person);
                    Connection.SaveChanges();
                }
                return "Follower Added Successfully";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }

        public List<TweetEntity> GetTweetsDetails(PersonEntity personDetails)
        {
            try
            {
                List<TweetEntity> poDetails;
                using (var Connection = new TwitterApplicationEntities())
                {
                    poDetails = (from p in Connection.TWEETs
                                 where p.user_id == personDetails.user_id
                                 select new TweetEntity
                                 {
                                     tweet_id=p.tweet_id,
                                     user_id = p.user_id,
                                     message = p.message,
                                     created=p.created
                                 }).ToList();
                }
                return poDetails;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }

        public string AddTweet(TweetEntity tweets)
        {
            try
            {
                var person = new TWEET()
                {
                    //tweet_id = tweets.tweet_id,
                    user_id = tweets.user_id,
                    message = tweets.message,
                    created = tweets.created
                };
                using (var Connection = new TwitterApplicationEntities())
                {
                    Connection.TWEETs.Add(person);
                    Connection.SaveChanges();
                }
                return "Tweet Added Successfully";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }

        public string UpdateTweet(TweetEntity tweets)
        {
            try
            {
                var person = new TWEET()
                {
                    tweet_id = tweets.tweet_id,
                    user_id = tweets.user_id,
                    message = tweets.message,
                    created = tweets.created
                };
                using (var Connection = new TwitterApplicationEntities())
                {
                    Connection.TWEETs.Add(person);
                    Connection.SaveChanges();
                }
                return "Tweet Updated Successfully";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }

        public string DeleteTweet(TweetEntity tweets)
        {
            try
            {
                using (var Connection = new TwitterApplicationEntities())
                {
                    Connection.Entry(tweets).State = EntityState.Deleted;
                    Connection.SaveChanges();
                }
                return "Tweet Deleted Successfully";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception);
            }
        }
    }
}
