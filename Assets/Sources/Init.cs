using UnityEngine;
using Models;
using Presenter;

public class Init : MonoBehaviour
{
    [SerializeField] private float _endPosition;
    [SerializeField] private float _inertiaMaxSpeed;
    [SerializeField] private float _inertiaUnitPerSecond;
    [SerializeField] private float _gravityScale;
    [SerializeField] private RotationView _view;

    private SphereInputRouter _input;
    private Transformable _model;
    private TransformablePresenter _presenter;
    private Inertia _inertia;
    private Gravity _gravity;

    public Transformable Model => _model;

    public Inertia Inertia => _inertia;

    private void Awake()
    {
        _model = new Transformable(new Range(0, 360 * _endPosition), new Range(0, _endPosition));
        //_gravity = new Gravity(_model, _gravityScale);
        _inertia = new Inertia(_model, _inertiaMaxSpeed, _inertiaUnitPerSecond);
        _input = new SphereInputRouter(_inertia);
        _presenter = new TransformablePresenter(_model, _view);
    }

    private void OnEnable()
    {
        _input.OnEnable();
        _presenter.OnEnable();
    }

    private void OnDisable()
    {
        _input.OnDisable();
        _presenter.OnDisable();
    }

    private void Update()
    {
        _inertia.Update();
        //_gravity.Update(Time.deltaTime);
    }
}