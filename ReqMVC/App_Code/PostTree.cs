using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReqMVC.Models.Domian;

namespace ReqMVC.App_Code
{
	public class PostTree
	{
		int postId;
		List<int> postsId;
		List<postoffice> posts;
		HdEntities entities;
		private void searchPostIdTree(int currentPostId)
		{
			if (!postsId.Contains(currentPostId))
				postsId.Add(currentPostId);
			var posts = from post in entities.posts where post.parent_id == currentPostId select post;
			foreach (var post in posts)
				searchPostIdTree(post.id);
		}

		/// <summary>
		/// Построение списка подчиненных подразделений
		/// </summary>
		/// <returns></returns>
		public IList<post> Build()
		{
			postsId = new List<int>();
			searchPostIdTree(postId);
			return entities.posts.OrderBy(x=>x.name).Where(x => postsId.Contains(x.id)).ToList();

		}

		public PostTree(int postId)
		{
			this.postId = postId;
			entities = new HdEntities();
		}
	}
}
