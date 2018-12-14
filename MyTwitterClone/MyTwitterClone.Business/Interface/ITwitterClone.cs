using MyTwitterClone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitterClone.Business.Interface
{
    public interface ITwitterClone
    {
        string AddUser(PersonEntity personDetails);
        bool LoginUser(PersonEntity personDetails);
        List<PersonEntity> GetUserDetails();
        string UpdateUser(PersonEntity personDetails);
        List<FollowingEntity> GetFollowerDetails(FollowingEntity followerDetails);
        List<FollowingEntity> GetFollowingDetails(FollowingEntity followerDetails);
        string AddFollower(FollowingEntity followerDetails);
        List<TweetEntity> GetTweetsDetails(PersonEntity personDetails);
        List<TweetEntity> GetFollowerTweetDtls(PersonEntity personDetails);
        List<TweetEntity> GetFollowingTweetDtls(PersonEntity personDetails);
        string AddTweet(TweetEntity tweets);
        string UpdateTweet(TweetEntity tweets);
        string DeleteTweet(TweetEntity tweets);
    }
}
