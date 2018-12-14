using MyTwitterClone.Data.Interfaces;
using MyTwitterClone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitterClone.Business.Model
{
    public class TwitterCloneModel: Interface.ITwitterClone
    {
        //constructor
        private readonly ITwitterClone _ITwitterClone;
        public TwitterCloneModel(ITwitterClone ITwitterClone)
        {
            this._ITwitterClone = ITwitterClone;
        }
        public string AddUser(PersonEntity personDetails)
        {
            personDetails.password = Helper.Helper.EncodePasswordMd5(personDetails.password);
            return _ITwitterClone.AddUser(personDetails);
        }
        public bool LoginUser(PersonEntity personDetails)
        {
            var encPassword = Helper.Helper.EncodePasswordMd5(personDetails.password);
            if(_ITwitterClone.GetUserDetails().Where(x => x.user_id == personDetails.user_id && x.password == encPassword).ToList().Count>0)
            {
                return true;
            }
            return false;
        }
        public List<PersonEntity> GetUserDetails()
        {
            return _ITwitterClone.GetUserDetails();
        }
        public string UpdateUser(PersonEntity personDetails)
        {
            return _ITwitterClone.UpdateUser(personDetails);
        }

        public List<FollowingEntity> GetFollowerDetails(FollowingEntity followerDetails)
        {
            return _ITwitterClone.GetFollowerDetails(followerDetails);
        }
        public List<FollowingEntity> GetFollowingDetails(FollowingEntity followerDetails)
        {
            return _ITwitterClone.GetFollowingDetails(followerDetails);
        }

        public string AddFollower(FollowingEntity followerDetails)
        {
            return _ITwitterClone.AddFollower(followerDetails);
        }

        public List<TweetEntity> GetTweetsDetails(PersonEntity personDetails)
        {
            return _ITwitterClone.GetTweetsDetails(personDetails);
        }
        public List<TweetEntity> GetFollowerTweetDtls(PersonEntity personDetails)
        {
            return _ITwitterClone.GetFollowerTweetDtls(personDetails);
        }
        public List<TweetEntity> GetFollowingTweetDtls(PersonEntity personDetails)
        {
            return _ITwitterClone.GetFollowingTweetDtls(personDetails);
        }

        public string AddTweet(TweetEntity tweets)
        {
            return _ITwitterClone.AddTweet(tweets);
        }

        public string UpdateTweet(TweetEntity tweets)
        {
            return _ITwitterClone.UpdateTweet(tweets);
        }

        public string DeleteTweet(TweetEntity tweets)
        {
            return _ITwitterClone.DeleteTweet(tweets);
        }
    }
}
