using LagDaemon.WWB.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.TestSuite
{
#if DEBUG

    [TestFixture]
    public class StoryStructureTests
    {
        StoryStructure story;


        [SetUp]
        public void Init()
        {
             story = new StoryStructure();
        }


        [Test]
        public void StoryStructure_adds_story_structure_elements()
        {
            int iter = 10;
            for (int i = 0; i < iter; i++)
            {
                story.AddChild(new StoryStructureElement());
            }
            Assert.AreEqual(story.ChildCount, iter);
        }


        [Test]
        public void StoryStructure_removes_story_elements()
        {
            int iter = 10;
            for (int i = 0; i < iter; i++)
            {
                story.AddChild(new StoryStructureElement());
            }
            foreach (StoryStructureElement element in story.Children)
            {
                story.Remove(element);
            }
            Assert.AreEqual(story.ChildCount, 0);
        }

        [Test]
        public void StoryStructure_clears_story_elements()
        {
            int iter = 10;
            for (int i = 0; i < iter; i++)
            {
                story.AddChild(new StoryStructureElement());
            }
            story.Clear();
            Assert.AreEqual(story.ChildCount, 0);
        }

        [Test]
        public void StoryStructureElement_adds_children()
        {
            int iter = 10;
            StoryStructureElement element = new StoryStructureElement();
            for (int i = 0; i < iter; i++)
            {
                element.AddChild(new StoryStructureElement());
            }
            Assert.AreEqual(element.ChildCount, iter);
        }

        [Test]
        public void StoryStructureElement_removes_children()
        {
            int iter = 10;
            StoryStructureElement element = new StoryStructureElement();
            for (int i = 0; i < iter; i++)
            {
                element.AddChild(new StoryStructureElement());
            }
            foreach (StoryStructureElement e in element.Children)
            {
                element.Remove(e);
            }
            Assert.AreEqual(element.ChildCount, 0);

        }

        [Test]
        public void StoryStructureElement_clears_children()
        {
            int iter = 10;
            StoryStructureElement element = new StoryStructureElement();
            for (int i = 0; i < iter; i++)
            {
                element.AddChild(new StoryStructureElement());
            }
            element.Clear();
            Assert.AreEqual(element.ChildCount, 0);

        }

    }

#endif
}
