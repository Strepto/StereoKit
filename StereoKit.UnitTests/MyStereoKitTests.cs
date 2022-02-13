using FluentAssertions;
using Xunit;

namespace StereoKit.UnitTests
{
    public class MyStereoKitTests : IClassFixture<StereoKitFixture>
    {
        [Fact]
        public void ModelNode_Mesh_CanBeNotNull()
        {
            var model = new Model();
            var node = model.AddNode(null, Matrix.Identity, Mesh.Cube, Material.Default);
            node.Mesh.Should().NotBeNull();
        }

        [Fact]
        public void ModelNode_Mesh_CanBeNull()
        {
            var model = new Model();
            var node = model.AddNode(null, Matrix.Identity);
            node.Mesh.Should().BeNull();
        }


        [Fact]
        public void Model_WhenIntersect_AndNoMeshNodes_DoesNotThrow()
        {
            var model = new Model();
            var node = model.AddNode(null, Matrix.Identity);
            model.Intersect(new Ray(), out var _).Should().BeFalse();
        }


        [Fact]
        public void Mesh_Intersect_Works()
        {
            var model = Mesh.Cube;
            model.Intersect(new Ray(-2 * Vec3.Forward, Vec3.Forward), out Ray hit).Should().BeTrue();
            hit.position.Should().Be(-Vec3.Forward / 2);
        }


        [Fact]
        public void HierarchyTest()
        {
            Hierarchy.Push(Matrix.T(Vec3.One));

            Hierarchy.ToWorld(Vec3.Zero).Should().Be(Vec3.One);

            Hierarchy.Pop();
        }

        [Fact]
        public void HierarchyScopeTest()
        {
            using (Hierarchy.PushScope(Matrix.T(Vec3.One)))
            {
                Hierarchy.ToWorld(Vec3.Zero).Should().Be(Vec3.One);
            }

            Hierarchy.ToWorld(Vec3.Zero).Should().Be(Vec3.Zero);
        }
    }
}
